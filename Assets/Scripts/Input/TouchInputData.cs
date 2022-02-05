using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.InputControl;
using UnityEngine.InputSystem;
using System;

namespace Runner.InputControl
{
    [CreateAssetMenu(menuName = "Runner/Input/Touch Input Data")]
    public class TouchInputData : AbstractInputData
    {
        [Header("Swipe base control")]
        [SerializeField] private bool swipeBaseInputActieve;

        public static event Action OnSwipeRight;
        public static event Action OnSwipeLeft;

        private float _firstTouchPosition;
        private float _currentTouchPosition;

        [Header("Tap base control")]
        [SerializeField] private bool tapBaseInputActieve;
        [SerializeField] private int tapCount;

        [Header("Tap and hold control")]
        [SerializeField] private bool holdBaseInputActieve;
        [SerializeField] private bool isHold;

        public override void ProcessInput()
        {
            
                if (swipeBaseInputActieve)
                {
                    SwipeBaseControl();
                }
                else if (tapBaseInputActieve)
                {
                    TapBaseControl();
                }
                else if (holdBaseInputActieve)
                {
                    HoldBaseControl();
                }
        }

        private void SwipeBaseControl()
        {
            if (Input.touchCount == 0)
            {
                return;
            }
            if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                _firstTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
            }
            if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Stationary)
            {
                Horizontal = 0;
                _firstTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
            }
            if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved)
            {
                _currentTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue().x;
                Horizontal = (_currentTouchPosition - _firstTouchPosition) / 10;
                Horizontal = Mathf.Clamp(Horizontal, -100, 100);
            }

            if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
            {
                Horizontal = 0;
            }
        }

        private void TapBaseControl()
        {
            if (Input.touchCount > tapCount)
            {

            }
        }

        private void HoldBaseControl()
        {

        }
    }
}
