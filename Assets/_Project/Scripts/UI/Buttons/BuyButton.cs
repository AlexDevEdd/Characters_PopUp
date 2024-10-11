using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
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