using GamePlay.Characters;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using Zenject;

namespace MonoDebug
{
    public sealed class PopUpDebug : MonoBehaviour
    {
        [SerializeField] private CharacterPopUpView _characterPopUpView;
        [SerializeField] private int _addExpValue = 50;
        
        private CharacterCollection _characterCollection;
        private CharacterPopUpPresenter _currentPresenter;
        
        [Inject]
        public void Construct(CharacterCollection characterPopUpSystem)
        {
            _characterCollection = characterPopUpSystem;
        }
        
        [Button(ButtonSizes.Gigantic), GUIColor(0, 1, 0)]
        public void ShowNextCharacter()
        {
            _characterPopUpView.Hide();
            var presenter = _characterCollection.GetNextPresenter();
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