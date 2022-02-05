using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.InputControl;
using Utilities.InputControl;
using DG.Tweening;

namespace Runner.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private AbstractInputData inputData;
        [SerializeField] private CharacterController _player;
        [SerializeField] private Rigidbody _playerRB;
        [SerializeField] private float _transitionTime;
        [SerializeField] private float _horizontalBoundry;
        [SerializeField] private float _movementSpeed;
        private void Update()
        {
            transform.DOMoveZ(transform.position.z + _movementSpeed * Time.deltaTime, _transitionTime);
            MoveHorizontal();
            MoveForward();
        }

        private void FixedUpdate()
        {
            //MoveHorizontal();
        }

        private void MoveForward()
        {
            //transform.DOMoveZ(transform.position.z + _movementSpeed * Time.deltaTime, _transitionTime);
            _player.Move(new Vector3(0, 0, _movementSpeed * Time.deltaTime * 0.1f));
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
            _player.Move(new Vector3(-_movementSpeed * Time.deltaTime, 0, 0));
        }

        private void MoveRight()
        {
            _player.Move(new Vector3(_movementSpeed * Time.deltaTime, 0, 0));
        }
    }
}
