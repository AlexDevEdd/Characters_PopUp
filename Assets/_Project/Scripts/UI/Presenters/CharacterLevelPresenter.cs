using System;
using _Project.Scripts.UI.Buttons;
using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.StaticData;
using UniRx;

namespace _Project.Scripts.UI.Presenters
{
    public sealed class CharacterLevelPresenter : ICharacterLevelPresenter
    {
        public IReadOnlyReactiveProperty<int> CurrentLevel => _currentLevel;
        public IReadOnlyReactiveProperty<int> CurrentExperience => _currentExperience;
        
        private readonly ReactiveProperty<int> _currentLevel;
        private readonly ReactiveProperty<int> _currentExperience;
        
        public CharacterLevelPresenter(CharacterLevel characterLevel)
        {
            _currentLevel = new ReactiveProperty<int>(characterLevel.CurrentLevel);
            _currentExperience = new ReactiveProperty<int>(characterLevel.CurrentExperience);
        }

        public void AddExperience(int range)
        {
             var xp = Math.Min(_currentExperience.Value + range, GetRequiredExperience());
             _currentExperience.Value = xp;
        }
        
        public bool TryLevelUp()
        {
            if (CanLevelUp())
            {
                _currentExperience.Value = 0;
                _currentLevel.Value++;
                return true;
            }

            return false;
        }

        public bool CanLevelUp() 
            => _currentExperience.Value == GetRequiredExperience();
        
        public string GetCurrentLevel() 
            => _currentLevel.Value.ToString();

        public string GetConvertedExperience() 
            => ConvertExperience();
        
        public float GetFillValue() 
            => _currentExperience.Value / (float)GetRequiredExperience();

        private int GetRequiredExperience() 
            => 100 * (_currentLevel.Value + 1);
        
        private string ConvertExperience() 
            => $"{_currentExperience}/{GetRequiredExperience()}";
    }
}