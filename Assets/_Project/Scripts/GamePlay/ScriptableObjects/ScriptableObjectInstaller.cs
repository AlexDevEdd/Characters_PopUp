using UnityEngine;
using Zenject;

namespace GamePlay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
    public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
    {
        [SerializeField, Space] 
        private GameBalance _balance;
        
        public override void InstallBindings()
        {
            BindGameBalance();
        }
        
        private void BindGameBalance()
        {
            Container.Bind<GameBalance>()
                .FromInstance(_balance)
                .AsSingle();
        }
    }
}