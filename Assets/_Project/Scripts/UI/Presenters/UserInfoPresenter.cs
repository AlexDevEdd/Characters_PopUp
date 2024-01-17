using _Project.Scripts.UI.Buttons;
using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.StaticData;
using UnityEngine;

namespace _Project.Scripts.UI.Presenters
{
    public sealed class UserInfoPresenter : IUserInfoPresenter
    {
        public string Name { get;}
        public string Description { get; }
        public Sprite Icon { get;}

        public UserInfoPresenter(UserInfo userInfo)
        {
            Name = userInfo.Name;
            Description = userInfo.Description;
            Icon = userInfo.Icon;
        }
    }
}