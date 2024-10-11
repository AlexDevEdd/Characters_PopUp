using System.Collections.Generic;
using GamePlay.ScriptableObjects;
using JetBrains.Annotations;
using UI;
using Zenject;

namespace GamePlay.Characters
{
    [UsedImplicitly]
    public sealed class CharacterCollection : IInitializable
    {
        private readonly List<ICharacterPopUpPresenter> _presenters = new ();
        private readonly GameBalance _balance;
        
        private int _currentIndex;
        
        public CharacterCollection(GameBalance balance)
        {
            _balance = balance;
        }
        
        public void Initialize()
        {
            CreatePresenters();
        }

        private void CreatePresenters()
        {
            foreach (var characterInfo in _balance.CharacterCatalog.CharacterInfos)
            {
                var presenter = new CharacterPopUpPresenter(characterInfo);
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