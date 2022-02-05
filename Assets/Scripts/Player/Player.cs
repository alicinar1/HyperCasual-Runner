using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Singleton;

namespace Runner.PlayerCont
{
    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private PlayerScriptableObject _playerScriptableObject;

        private void Start()
        {
            _playerScriptableObject.playerStat.energyCount = 0;
        }

        public PlayerScriptableObject PlayerSO
        {
            get { return _playerScriptableObject; }
        }

        public void IncreaseEnergyCount()
        {
            _playerScriptableObject.playerStat.energyCount += 1;
        }

        public void DecreaseEnergyCount()
        {
            _playerScriptableObject.playerStat.energyCount -= 1;
        }

    }
}
