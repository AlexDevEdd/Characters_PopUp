using System;
using _Project.Scripts.UI.StaticData;
using Sirenix.OdinInspector;

namespace _Project.Scripts.Core.Installers.ScriptableObjects
{
    [Serializable]
    public class GameBalance
    {
        [Title("CharacterCatalog", TitleAlignment = TitleAlignments.Centered)]
        public CharacterCatalog CharacterCatalog;
    }
}