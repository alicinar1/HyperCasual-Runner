using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.PlayerCont
{
    [CreateAssetMenu(menuName = "Runner/Player/Player Scriptable Object")]
    public class PlayerScriptableObject : ScriptableObject
    {
        [SerializeField] private float _playerForwardMovementSpeed;
        [SerializeField] private float _playerLateralMovementSpeed;
        [SerializeField] private float _playerJumpForce;

        public float PlayerForwardMovementSpeed { get { return _playerForwardMovementSpeed; } }
        public float PlayerLateralMovementSpeed { get { return _playerLateralMovementSpeed; } }
        public float PlayerJump { get { return _playerJumpForce; } }

        public PlayerStats playerStat = new PlayerStats();
    }
}
