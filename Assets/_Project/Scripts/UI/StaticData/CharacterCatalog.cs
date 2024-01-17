using System.Linq;
using UnityEngine;

namespace _Project.Scripts.UI.StaticData
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