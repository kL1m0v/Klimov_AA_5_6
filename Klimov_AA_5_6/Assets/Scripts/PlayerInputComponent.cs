using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Car
{
    public class PlayerInputComponent : MonoBehaviour
    {
        private PlayerActions _playerActions;

        private void Awake()
        {
            _playerActions = new();
        }

        private void OnEnable()
        {
            _playerActions.CarControl.Enable();
        }

        private void OnDisable()
        {
            _playerActions.CarControl.Disable();
        }

        public float ReadInputOfMovementForwardOrReverse()
        {
            return _playerActions.CarControl.ForwardOrReverse.ReadValue<float>();
        }

        public float ReadInputOfWheelRotation()
        {
            return _playerActions.CarControl.TurningWheel.ReadValue<float>();
        }

        public float ReadInputBrake() 
        {
            return _playerActions.CarControl.Brake.ReadValue<float>();
        }
    }
}
