using TMPro;
using UnityEngine;

namespace UI
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