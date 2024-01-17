using System;

namespace _Project.Scripts.UI.StaticData
{
    [Serializable]
    public sealed class CharacterInfo
    {
        public UserInfo UserInfo;
        public CharacterLevel CharacterLevel;
        public CharacterStat[] CharacterStats; 
    }
}