using UniRx;

namespace UI
{
    public interface ICharacterStatPresenter
    {
        public string Name { get; }
        public IReadOnlyReactiveProperty<int> StatValue { get; }
        public void IncreaseStat();
    }
}