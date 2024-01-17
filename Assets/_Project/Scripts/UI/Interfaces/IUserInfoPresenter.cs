using UnityEngine;

namespace _Project.Scripts.UI.Interfaces
{
    public interface IUserInfoPresenter
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}