using System.Collections.Generic;
using _Project.Scripts.Core.Installers.ScriptableObjects;
using _Project.Scripts.Factories;
using _Project.Scripts.UI.Interfaces;
using Zenject;

namespace _Project.Scripts.Systems
{
    public class CharacterPopUpSystem : IInitializable
    {
        private readonly GameBalance _balance;
        private readonly CharacterPresenterFactory _characterPresenterFactory;
        
        private int _currentIndex;
        private readonly List<ICharacterPopUpPresenter> _presenters = new ();
        
        public CharacterPopUpSystem(GameBalance balance, CharacterPresenterFactory characterPresenterFactory)
        {
            _balance = balance;
            _characterPresenterFactory = characterPresenterFactory;
        }
        
        public void Initialize()
        {
            CreatePresenters();
        }

        private void CreatePresenters()
        {
            foreach (var characterInfo in _balance.CharacterCatalog.CharacterInfos)
            {
                var presenter = _characterPresenterFactory.Create(characterInfo);
                _presenters.Add(presenter);
            }
        }
        
        public ICharacterPopUpPresenter GetNextPresenter()
        {
            if (_currentIndex >= _presenters.Count)
                _currentIndex = 0;
            
            var presenter = _presenters[_currentIndex];
            _currentIndex++;
            return presenter;
        }
    }
}