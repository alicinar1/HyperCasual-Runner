using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.InputControl;
using Runner.PlayerCont;
using Utilities.InputControl;
using DG.Tweening;

namespace Runner.PlayerCont.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private AbstractInputData inputData;
        [SerializeField] private CharacterController _player;
        [SerializeField] private float _horizontalBoundry;

        private void Update()
        {
            MoveHorizontal();
            MoveForward();
        }

        private void MoveForward()
        {
            _player.Move(new Vector3(0, 0, Player.Instance.PlayerSO.PlayerForwardMovementSpeed * Time.deltaTime));
        }

        private void MoveHorizontal()
        {
            if (transform.position.x > _horizontalBoundry)
            {
                MoveLeft();
                return;
            }
            if (transform.position.x < -_horizontalBoundry)
            {
                MoveRight();
                return;
            }

            if (inputData.Horizontal > 0)
            {
                if (inputData.Horizontal > 0.4)
                {
                    Debug.Log("MoveRight");
                    MoveRight();
                }
            }
            else
            {
                if (inputData.Horizontal < -0.4)
                {
                    Debug.Log("MoveLeft");
                    MoveLeft();
                }
            }
        }

        private void MoveLeft()
        {
            _player.Move(new Vector3(-Player.Instance.PlayerSO.PlayerLateralMovementSpeed * Time.deltaTime, 0, 0));
        }

        private void MoveRight()
        {
            _player.Move(new Vector3(Player.Instance.PlayerSO.PlayerLateralMovementSpeed * Time.deltaTime, 0, 0));
        }
    }
}
