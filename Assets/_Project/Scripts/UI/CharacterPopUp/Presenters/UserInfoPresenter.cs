using GamePlay.Characters.StaticData;
using UnityEngine;

namespace UI
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