using System;
using UnityEngine;

namespace GamePlay.Characters.StaticData
{
    [Serializable]
    public sealed class CharacterLevel
    {
        [field: SerializeField]
        public int CurrentLevel { get; private set; } = 1;
        
        [field: SerializeField]
        public int CurrentExperience { get; private set; }
    }
}