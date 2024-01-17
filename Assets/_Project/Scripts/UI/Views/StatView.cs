using _Project.Scripts.UI.Buttons;
using _Project.Scripts.UI.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.UI.Views
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _statName;
        [SerializeField] private TextMeshProUGUI _value;

        private ICharacterStatPresenter _statPresenter;
        
        public void Init(ICharacterStatPresenter stat, CompositeDisposable disposable)
        {
            _statPresenter = stat;
            _statName.text = stat.Name;
            _statPresenter.StatValue.Subscribe(OnUpdateValue).AddTo(disposable);
            OnUpdateValue(_statPresenter.StatValue.Value);
        }

        private void OnUpdateValue(int value) 
            => _value.text = value.ToString();
        
    }
}