using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Installers.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameBalanceInstaller", menuName = "Installers/GameBalanceInstaller")]
    public class GameBalanceInstaller : ScriptableObjectInstaller<GameBalanceInstaller>
    {
        [SerializeField] private GameBalance _balance;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameBalance>().FromInstance(_balance).AsSingle();

        }
    }
}