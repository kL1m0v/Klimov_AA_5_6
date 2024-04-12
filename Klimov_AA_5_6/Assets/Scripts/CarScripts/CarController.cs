using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car 
{
    public class CarController : MonoBehaviour
    {
        private WheelsController _wheelController;
        private PlayerInputComponent _playerInputComponent;
        private Rigidbody _rigidbody;
        [SerializeField]
        private Vector3 _centerOfMass;
        private bool canMove = false;

        public bool CanMove { get => canMove; set => canMove = value; }

        private void Awake()
        {
            _wheelController = GetComponent<WheelsController>();
            _playerInputComponent = GetComponent<PlayerInputComponent>();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = _centerOfMass;
        }

        private void FixedUpdate()
        {
            if (CanMove)
            {
                _wheelController.SetMotorTorqueForMotorizedWheels(_playerInputComponent.ReadInputOfMovementForwardOrReverse());
                _wheelController.SetSteerAngleForSteeringWheels(_playerInputComponent.ReadInputOfWheelRotation());
                _wheelController.AddBreakTorque(_playerInputComponent.ReadInputBrake());
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), 0.5f);
        }
    }
}
