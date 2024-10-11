using System.Collections.Generic;
using GamePlay.Characters.StaticData;
using Sirenix.Utilities;
using UniRx;

namespace UI
{
    public sealed class CharacterPopUpPresenter : ICharacterPopUpPresenter
    {
        public ICharacterLevelPresenter CharacterLevelPresenter { get; }
        public IUserInfoPresenter UserInfoPresenter { get; }
        public List<ICharacterStatPresenter> Stats { get; private set; }
        public ReactiveCommand LevelUpCommand { get; }
        
        private CompositeDisposable _compositeDisposable;
        
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
        {
            Stats.Add(new CharacterStatPresenter(stat));
        }

        public void Subscribe()
        {
            _compositeDisposable = new CompositeDisposable();
            LevelUpCommand.Subscribe(OnLevelUpCommand)
               .AddTo(_compositeDisposable);
        }

        public void UnSubscribe()
        {
            _compositeDisposable?.Dispose();
        }

        private void OnLevelUpCommand(Unit _)
        {
            CharacterLevelPresenter.TryLevelUp();
            foreach (var stat in Stats)
                stat.IncreaseStat();
        }
    }
}