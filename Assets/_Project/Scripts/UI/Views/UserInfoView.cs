using _Project.Scripts.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Views
{
    public sealed class UserInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _icon;
        
        public void Init(IUserInfoPresenter userInfo)
        {
            _userName.text = userInfo.Name;
            _description.text = userInfo.Description;
            _icon.sprite = userInfo.Icon;
        }
    }
}