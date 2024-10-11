using System;
using GamePlay.Characters.StaticData;
using Sirenix.OdinInspector;

namespace GamePlay.ScriptableObjects
{
    [Serializable]
    public class GameBalance
    {
        [Title("CharacterCatalog", TitleAlignment = TitleAlignments.Centered)]
        public CharacterCatalog CharacterCatalog;
    }
}