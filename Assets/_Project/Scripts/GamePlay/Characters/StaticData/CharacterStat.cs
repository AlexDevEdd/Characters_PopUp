using System;
using UnityEngine;

namespace GamePlay.Characters.StaticData
{
    [Serializable]
    public sealed class CharacterStat
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public int Value { get; private set; }

        public string GetValue()
        {
            return Value.ToString();
        }

    }
}