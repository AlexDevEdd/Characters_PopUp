using System.Linq;
using UnityEngine;

namespace GamePlay.Characters.StaticData
{
    [CreateAssetMenu(fileName = "CharacterCatalog", menuName = "Data/New CharacterCatalog")]
    public sealed class CharacterCatalog : ScriptableObject
    {
        public CharacterInfo[] CharacterInfos;

        public CharacterInfo GetCharacterInfo(string key)
        {
            return CharacterInfos.FirstOrDefault(i => i.UserInfo.Name == key);
        }
    }
}