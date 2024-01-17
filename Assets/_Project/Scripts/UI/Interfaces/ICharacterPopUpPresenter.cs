using System.Collections.Generic;
using _Project.Scripts.UI.Buttons;
using _Project.Scripts.UI.StaticData;
using UniRx;

namespace _Project.Scripts.UI.Interfaces
{
    public interface ICharacterPopUpPresenter
    {
        public ICharacterLevelPresenter CharacterLevelPresenter { get; }
        public IUserInfoPresenter UserInfoPresenter { get; }
        public List<ICharacterStatPresenter> Stats { get; }
        public ReactiveCommand LevelUpCommand { get; }

        public CompositeDisposable CompositeDisposable { get; }

        public void Subscribe();
        public void UnSubscribe();
    }
}