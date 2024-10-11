using TMPro;
using UniRx;
using UnityEngine;

namespace UI
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _statName;
        
        [SerializeField]
        private TextMeshProUGUI _value;

        private ICharacterStatPresenter _statPresenter;
        private CompositeDisposable _compositeDisposable;
        
        public void Show(ICharacterStatPresenter stat)
        {
            _statPresenter = stat;
            _statName.text = stat.Name;
            _compositeDisposable = new CompositeDisposable();
            
            _statPresenter.StatValue
                .Subscribe(OnUpdateValue)
                .AddTo(_compositeDisposable);
            
            OnUpdateValue(_statPresenter.StatValue.Value);
        }

        private void OnUpdateValue(int value)
        {
            _value.text = value.ToString();
        }

        public void Hide()
        {
            _compositeDisposable?.Dispose();
        }
    }
}