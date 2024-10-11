using System.Collections.Generic;
using UniRx;

namespace UI
{
    public interface ICharacterPopUpPresenter
    {
        public ICharacterLevelPresenter CharacterLevelPresenter { get; }
        public IUserInfoPresenter UserInfoPresenter { get; }
        public List<ICharacterStatPresenter> Stats { get; }
        public ReactiveCommand LevelUpCommand { get; }
        public void Subscribe();
        public void UnSubscribe();
    }
}