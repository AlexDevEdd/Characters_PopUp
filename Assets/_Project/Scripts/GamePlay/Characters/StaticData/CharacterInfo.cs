using System;
using UnityEngine;

namespace GamePlay.Characters.StaticData
{
    [Serializable]
    public sealed class CharacterInfo
    {
        [field:SerializeField]
        public UserInfo UserInfo { get; private set; }
        
        [field:SerializeField]
        public CharacterLevel CharacterLevel { get; private set; }
        
        [field:SerializeField]
        public CharacterStat[] CharacterStats { get; private set; }
    }
}