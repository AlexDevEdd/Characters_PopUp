using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class CharacterLevelView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currentLevelText;
        
        [SerializeField]
        private TextMeshProUGUI _currentExperienceText;
        
        [SerializeField]
        private Image _fillImage;
        
        [Space]
        [SerializeField]
        private Sprite _completedSprite;
        
        [SerializeField]
        private Sprite _inProgressSprite;

        private ExperienceState _state;
        
        public void SetProgress(float progress)
        {
            _fillImage.fillAmount = progress;
        }

        public void UpdateLevel(string level)
        {
            _currentLevelText.text = level;
        }

        public void UpdateExperience(string experience)
        {
            _currentExperienceText.text = experience;
        }

        public void SetState(ExperienceState state)
        {
            _state = state;
            TryToggleExperienceState();
        }

        private void TryToggleExperienceState()
        {
            var isCompleted = _state == ExperienceState.Completed;
            _fillImage.sprite = isCompleted
                ? _completedSprite
                : _inProgressSprite;
        }
    }
}