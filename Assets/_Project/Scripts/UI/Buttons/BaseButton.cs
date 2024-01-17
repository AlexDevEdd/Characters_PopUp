using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Buttons
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [Space] 
        [SerializeField] private Image _buttonBackground;
        [SerializeField] private Sprite _availableButtonSprite;
        [SerializeField] private Sprite _lockedButtonSprite;
        
        [Space] 
        [SerializeField] protected State State;

        public Button Button => _button;

        public void AddListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            _button.onClick.RemoveListener(action);
        }
        
        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? State.AVAILABLE : State.LOCKED;
            SetState(state);
        }

        public virtual void SetState(State state)
        {
            State = state;

            if (state == State.AVAILABLE)
            {
                _button.interactable = true;
                _buttonBackground.sprite = _availableButtonSprite;
            }
            else if (state == State.LOCKED)
            {
                _button.interactable = false;
                _buttonBackground.sprite = _lockedButtonSprite;
            }
            else
            {
                throw new Exception($"Undefined button state {state}!");
            }
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            try
            {
                SetState(State);
            }
            catch (Exception)
            {
                // ignored
            }
        }
#endif
    }
    
    public enum State
    {
        AVAILABLE,
        LOCKED,
    }
}