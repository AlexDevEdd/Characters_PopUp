using System;
using GamePlay.Characters.StaticData;
using UniRx;

namespace UI
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
        {
            return _currentExperience.Value == GetRequiredExperience();
        }

        public string GetCurrentLevel()
        {
            return $"Level {_currentLevel.Value}";
        }

        public string GetConvertedExperience()
        {
            return ConvertExperience();
        }

        public float GetFillValue()
        {
            return _currentExperience.Value / (float)GetRequiredExperience();
        }

        private int GetRequiredExperience()
        {
            return 100 * (_currentLevel.Value + 1);
        }

        private string ConvertExperience()
        {
            return $"{_currentExperience}/{GetRequiredExperience()}";
        }
    }
}