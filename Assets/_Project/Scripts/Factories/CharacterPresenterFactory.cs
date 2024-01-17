using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.Presenters;
using _Project.Scripts.UI.StaticData;

namespace _Project.Scripts.Factories
{
    public sealed class CharacterPresenterFactory
    {
        public ICharacterPopUpPresenter Create(CharacterInfo characterInfo)
        {
            return new CharacterPopUpPresenter(characterInfo);
        }
    }
}