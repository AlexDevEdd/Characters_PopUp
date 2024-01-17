using System;

namespace _Project.Scripts.UI.StaticData
{
    [Serializable]
    public sealed class CharacterStat
    {
        public string Name;

        public int Value;

        public string GetValue()
        {
            return Value.ToString();
        }

    }
}