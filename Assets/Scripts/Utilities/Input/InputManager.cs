using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.InputControl
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private AbstractInputData[] _inputDataArray;

        private void Start()
        {
            StopInputManager();
        }

        private void OnEnable()
        {
            MenuController.OnStartGame += StartInputManager;
            MenuController.OnPauseGame += StopInputManager;
            MenuController.OnResumeGame += StartInputManager;
        }

        private void OnDestroy()
        {
            MenuController.OnStartGame -= StartInputManager;
            MenuController.OnPauseGame -= StopInputManager;
            MenuController.OnResumeGame -= StartInputManager;
        }

        private void Update()
        {
            for (int i = 0; i < _inputDataArray.Length; i++)
            {
                _inputDataArray[i].ProcessInput();
            }
        }

        private void StartInputManager()
        {
            Debug.Log("InputManagerEnabled");
            enabled = true;
        }

        private void StopInputManager()
        {
            Debug.Log("InputManagerDisabled");
            enabled = false;
        }

        private void AddInputData(AbstractInputData inputData)
        {

        }

        private void RemoveInputData(AbstractInputData inputData)
        {

        }
    }
}
