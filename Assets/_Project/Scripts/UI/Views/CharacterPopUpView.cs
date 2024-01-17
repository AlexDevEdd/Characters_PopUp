using System.Collections.Generic;
using _Project.Scripts.UI.Buttons;
using _Project.Scripts.UI.Enums;
using _Project.Scripts.UI.Interfaces;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.UI.Views
{
    public sealed class CharacterPopUpView : MonoBehaviour
    {
        [SerializeField] private UserInfoView _userInfoView;
        [SerializeField] private CharacterLevelView _characterLevelView;
        
        [Space]
        [SerializeField] private List<StatView> _statViews;

        [Space]
        [SerializeField] private SimpleButton _levelUpBtn;
        [SerializeField] private CloseButton _closeBtn;
        
        private ICharacterPopUpPresenter _characterPopUpPresenter;
        private ICharacterLevelPresenter _characterLevelPresenter;
        
        public void Show(ICharacterPopUpPresenter popUpPresenter)
        {
            _characterPopUpPresenter = popUpPresenter;
            _characterPopUpPresenter.Subscribe();
            
            InitUserInfo();
            InitStats();
            UpdateLevelView(out var isCanLevelUp);
            UpdateLevelUpButtonState(isCanLevelUp);
            Subscribes();
            
            _closeBtn.AddListener(Hide);
            gameObject.SetActive(true);
        }

        private void InitUserInfo() 
            => _userInfoView.Init(_characterPopUpPresenter.UserInfoPresenter);

        private void UpdateLevelView(out bool isCanLevelUp)
        {
            _characterLevelPresenter = _characterPopUpPresenter.CharacterLevelPresenter;
            _characterLevelView.UpdateLevel(_characterLevelPresenter.GetCurrentLevel());
            _characterLevelView.UpdateExperience(_characterLevelPresenter.GetConvertedExperience());
            _characterLevelView.SetProgress(_characterLevelPresenter.GetFillValue());

            isCanLevelUp = _characterLevelPresenter.CanLevelUp();
            _characterLevelView.SetState(isCanLevelUp
                ? ExperienceState.Completed
                : ExperienceState.InProgress);
        }

        private void InitStats()
        {
            for (int i = 0; i < _characterPopUpPresenter.Stats.Count; i++)
            {
                if (_statViews.Count >= i)
                    _statViews[i].Init(_characterPopUpPresenter.Stats[i], _characterPopUpPresenter.CompositeDisposable);
            }
        }

        private void Subscribes()
        {
            _characterLevelPresenter.CurrentExperience
                .SkipLatestValueOnSubscribe()
                .Subscribe(OnExperienceChanged)
                .AddTo(_characterPopUpPresenter.CompositeDisposable);
            
            _characterLevelPresenter.CurrentLevel
                .SkipLatestValueOnSubscribe()
                .Subscribe(OnLevelChanged)
                .AddTo(_characterPopUpPresenter.CompositeDisposable);
            
            _characterPopUpPresenter.LevelUpCommand
                .BindTo(_levelUpBtn.Button)
                .AddTo(_characterPopUpPresenter.CompositeDisposable); 
        }

        private void OnLevelChanged(int value)
        {
            _characterLevelView.UpdateLevel(_characterLevelPresenter.GetCurrentLevel());
            _characterLevelView.UpdateExperience(_characterLevelPresenter.GetConvertedExperience());
            _characterLevelView.SetProgress(_characterLevelPresenter.GetFillValue());
        }
        
        private void OnExperienceChanged(int value)
        {
            _characterLevelView.UpdateExperience(_characterLevelPresenter.GetConvertedExperience());
            _characterLevelView.SetProgress(_characterLevelPresenter.GetFillValue());

            var isCanLevelUp = _characterLevelPresenter.CanLevelUp();
            _characterLevelView.SetState(isCanLevelUp
                ? ExperienceState.Completed
                : ExperienceState.InProgress);
            
            UpdateLevelUpButtonState(isCanLevelUp);
        }

        private void UpdateLevelUpButtonState(bool isCanLevelUp) 
            => _levelUpBtn.SetAvailable(isCanLevelUp);

        public void Hide()
        {
            if (isActiveAndEnabled)
            {
                gameObject.SetActive(false);
                _closeBtn.RemoveListener(Hide);
                _characterPopUpPresenter.UnSubscribe(); 
            }
        }
    }
}