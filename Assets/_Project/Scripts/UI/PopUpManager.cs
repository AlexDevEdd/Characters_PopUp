using _Project.Scripts.Systems;
using _Project.Scripts.UI.Presenters;
using _Project.Scripts.UI.Views;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public sealed class PopUpManager : MonoBehaviour
    {
        [SerializeField] private CharacterPopUpView _characterPopUpView;
        [SerializeField] private int _addExpValue = 50;
        
        private CharacterPopUpSystem _characterPopUpSystem;
        private CharacterPopUpPresenter _currentPresenter;
        
        [Inject]
        public void Construct(CharacterPopUpSystem characterPopUpSystem)
        {
            _characterPopUpSystem = characterPopUpSystem;
        }
        
        [Button(ButtonSizes.Gigantic), GUIColor(0, 1, 0)]
        public void ShowNextCharacter()
        {
            _characterPopUpView.Hide();
            var presenter = _characterPopUpSystem.GetNextPresenter();
            _characterPopUpView.Show(presenter);
            _currentPresenter = presenter as CharacterPopUpPresenter;
        }
        
        [Button(ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1)]
        public void AddExp()
        {
            if(!_currentPresenter.CharacterLevelPresenter.CanLevelUp())
                _currentPresenter.CharacterLevelPresenter.AddExperience(_addExpValue);
        }
    }
}