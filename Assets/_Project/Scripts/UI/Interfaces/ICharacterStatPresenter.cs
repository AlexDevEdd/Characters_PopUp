using UniRx;

namespace _Project.Scripts.UI.Interfaces
{
    public interface ICharacterStatPresenter
    {
        public string Name { get; }
        public IReadOnlyReactiveProperty<int> StatValue { get; }
        public void IncreaseStat();
    }
}