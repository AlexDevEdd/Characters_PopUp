using GamePlay.Characters.StaticData;
using UniRx;

namespace UI
{
    public sealed class CharacterStatPresenter : ICharacterStatPresenter
    {
        private const int INCREASE_VALUE = 5;
        public string Name { get; }
        public IReadOnlyReactiveProperty<int> StatValue => _statValue;
        
        private readonly ReactiveProperty<int> _statValue;
        
        public CharacterStatPresenter(CharacterStat stat)
        {
            Name = stat.Name;
            _statValue = new ReactiveProperty<int>(stat.Value);
        }
        
        public void IncreaseStat()
        {
            _statValue.Value += INCREASE_VALUE;
        }
    }
}