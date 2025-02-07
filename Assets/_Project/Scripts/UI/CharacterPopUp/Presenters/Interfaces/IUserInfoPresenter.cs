using System;
using UnityEngine;

namespace UI
{
    public interface IUserInfoPresenter
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}