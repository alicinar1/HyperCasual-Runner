using Runner.PlayerCont.Movement;
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

        private void OnEnable()
        {
            MenuController.OnStartGame += StartAnimations;
            MenuController.OnStartGame += StartPlayerMovement;
            MenuController.OnResumeGame += StartAnimations;
            MenuController.OnResumeGame += StartPlayerMovement;
            MenuController.OnPauseGame += StopAnimations;
            MenuController.OnPauseGame += StopPlayerMovement;
        }

        private void OnDisable()
        {
            MenuController.OnStartGame -= StartAnimations;
            MenuController.OnStartGame -= StartPlayerMovement;
            MenuController.OnResumeGame -= StartAnimations;
            MenuController.OnResumeGame -= StartPlayerMovement;
            MenuController.OnPauseGame -= StopAnimations;
            MenuController.OnPauseGame -= StopPlayerMovement;
        }

        public PlayerScriptableObject PlayerSO
        {
            get { return _playerScriptableObject; }
        }

        private void StartAnimations()
        {
            Player.Instance.GetComponent<Animator>().enabled = true;
        }

        private void StopAnimations()
        {
            Player.Instance.GetComponent<Animator>().enabled = false;
        }

        private void StartPlayerMovement()
        {
            Player.Instance.GetComponent<PlayerMovement>().enabled = true;
        }

        private void StopPlayerMovement()
        {
            Player.Instance.GetComponent<PlayerMovement>().enabled = false;
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
