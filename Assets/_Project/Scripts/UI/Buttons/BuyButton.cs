using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Buttons
{
    public sealed class BuyButton : MonoBehaviour
    {
        [Space] 
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _priceIcon;
        
        public void SetPrice(string price)
        {
            _priceText.text = price;
        }

        public void SetIcon(Sprite icon)
        {
            _priceIcon.sprite = icon;
        }
    }
}