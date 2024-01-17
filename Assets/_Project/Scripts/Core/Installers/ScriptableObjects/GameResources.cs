using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Core.Installers.ScriptableObjects
{
    [Serializable]
    public class GameResources
    {
        [SerializeField] private List<Sprite> _icons;
        [SerializeField] private Sprite _placeholder;
        
        public Sprite GetSprite(string key)
        {
            var result = _icons.FirstOrDefault(s => s.name == key);
            return result == null ? _placeholder : result;
        }
        
        public Sprite GetSprite<T>(T type) where T: Enum
        {
            var result = _icons.FirstOrDefault(s => s.name.Equals(type.ToString()));
            return result == null ? _placeholder : result;
        }
    }
}