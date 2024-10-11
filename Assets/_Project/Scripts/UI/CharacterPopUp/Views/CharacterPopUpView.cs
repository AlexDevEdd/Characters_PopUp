using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace UI
{
    public sealed class CharacterPopUpView : MonoBehaviour
    {
        [SerializeField]
        private UserInfoView _userInfoView;
        
        [SerializeField]
        private CharacterLevelView _characterLevelView;
        
        [Space]
        [SerializeField]
        private List<StatView> _statViews;
        
        [Space]
        [SerializeField]
        private SimpleButton _levelButton; 
        
        [SerializeField]
        private CloseButton _closeButton;
        
        private ICharacterPopUpPresenter _characterPopUpPresenter;
        private ICharacterLevelPresenter _characterLevelPresenter;
        
        private CompositeDisposable _compositeDisposable;
        
        public void Show(ICharacterPopUpPresenter popUpPresenter)
        {
            _characterPopUpPresenter = popUpPresenter;
            _characterPopUpPresenter.Subscribe();
            
            ShowUserInfo();
            ShowStats();
            UpdateLevelView(out var isCanLevelUp);
            UpdateLevelUpButtonState(isCanLevelUp);
            Subscribe();
            
            _closeButton.AddListener(Hide);
            gameObject.SetActive(true);
        }

        private void ShowUserInfo()
        {
            _userInfoView.Show(_characterPopUpPresenter.UserInfoPresenter);
        }

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

        private void ShowStats()
        {
            for (int i = 0; i < _characterPopUpPresenter.Stats.Count; i++)
            {
                if (_statViews.Count >= i)
                    _statViews[i].Show(_characterPopUpPresenter.Stats[i]);
            }
        }

        private void Subscribe()
        {
            _compositeDisposable = new CompositeDisposable();
            _characterLevelPresenter.CurrentExperience
                .SkipLatestValueOnSubscribe()
                .Subscribe(OnExperienceChanged)
                .AddTo(_compositeDisposable);
            
            _characterLevelPresenter.CurrentLevel
                .SkipLatestValueOnSubscribe()
                .Subscribe(OnLevelChanged)
                .AddTo(_compositeDisposable);
            
            _characterPopUpPresenter.LevelUpCommand
                .BindTo(_levelButton.Button)
                .AddTo(_compositeDisposable); 
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
        {
            _levelButton.SetAvailable(isCanLevelUp);
        }

        public void Hide()
        {
            if (isActiveAndEnabled)
            {
                gameObject.SetActive(false);
                Unsubscribe();
            }
        }

        private void Unsubscribe()
        {
            _closeButton.RemoveListener(Hide);
            _compositeDisposable?.Dispose();
            _characterPopUpPresenter?.UnSubscribe();
            HideStats();
        }

        private void HideStats()
        {
            for (int i = 0; i < _characterPopUpPresenter?.Stats.Count; i++)
            {
                if (_statViews.Count >= i)
                    _statViews[i].Hide();
            }
        }
    }
}