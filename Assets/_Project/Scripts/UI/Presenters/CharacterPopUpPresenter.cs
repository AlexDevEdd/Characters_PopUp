using System.Collections.Generic;
using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.StaticData;
using Sirenix.Utilities;
using UniRx;

namespace _Project.Scripts.UI.Presenters
{
    public sealed class CharacterPopUpPresenter : ICharacterPopUpPresenter
    {
        public ICharacterLevelPresenter CharacterLevelPresenter { get; }
        public IUserInfoPresenter UserInfoPresenter { get; }
        
        public List<ICharacterStatPresenter> Stats { get; private set; }
        public ReactiveCommand LevelUpCommand { get; }
        public CompositeDisposable CompositeDisposable { get; private set; }

        public CharacterPopUpPresenter(CharacterInfo characterInfo)
        {
            LevelUpCommand = new ReactiveCommand();
            UserInfoPresenter = new UserInfoPresenter(characterInfo.UserInfo);
            CharacterLevelPresenter = new CharacterLevelPresenter(characterInfo.CharacterLevel);
            SetUpCharacterStats(characterInfo);
        }

        private void SetUpCharacterStats(CharacterInfo characterInfo)
        {
            Stats = new List<ICharacterStatPresenter>(characterInfo.CharacterStats.Length);
            characterInfo.CharacterStats.ForEach(AddNewCharacterStat);
        }

        private void AddNewCharacterStat(CharacterStat stat) 
            => Stats.Add(new CharacterStatPresenter(stat));

        public void Subscribe()
        {
            CompositeDisposable = new CompositeDisposable();
            LevelUpCommand.Subscribe(OnLevelUpCommand)
               .AddTo(CompositeDisposable);
        }

        public void UnSubscribe()
        {
            CompositeDisposable?.Dispose();
        }

        private void OnLevelUpCommand(Unit _)
        {
            CharacterLevelPresenter.TryLevelUp();
            foreach (var stat in Stats)
                stat.IncreaseStat();
        }
    }
}