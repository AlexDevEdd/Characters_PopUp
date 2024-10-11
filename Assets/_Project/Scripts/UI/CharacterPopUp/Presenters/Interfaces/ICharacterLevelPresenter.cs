using System;
using UniRx;

namespace UI
{
    public interface ICharacterLevelPresenter
    {
        public IReadOnlyReactiveProperty<int> CurrentLevel { get; }
        public IReadOnlyReactiveProperty<int> CurrentExperience { get; }
        public void AddExperience(int range);
        public string GetCurrentLevel();
        public string GetConvertedExperience();
        public float GetFillValue(); 
        public bool CanLevelUp();
        public bool TryLevelUp();
    }
}