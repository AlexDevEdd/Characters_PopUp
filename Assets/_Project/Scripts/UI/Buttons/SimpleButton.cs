using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI.Buttons
{
    public class SimpleButton : BaseButton
    {
        [Space]
        [SerializeField] private TextMeshProUGUI _buttonText;
        
        public void SetButtonText(string text)
        {
            _buttonText.text = text;
        }
    }
}