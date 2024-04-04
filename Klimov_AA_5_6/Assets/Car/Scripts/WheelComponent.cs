using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Car
{
    public class WheelComponent : MonoBehaviour
    {
        [SerializeField]
        private bool _isSteeringWheel;
        [SerializeField]
        private bool _isMotorizingWheel;
        
        private WheelCollider _wheelCollider;
        [SerializeField]
        private Transform _wheelTransform;

        public bool IsSteeringWheel { get => _isSteeringWheel; }
        public bool IsMotorizingWheel { get => _isMotorizingWheel; }

        private void Awake()
        {
            _wheelCollider = GetComponent<WheelCollider>();
        }

        private void Update()
        {
            UpdateWheelTransformPositionAndRotation();
        }

        public void SetMotorTorque(float torque)
        {
            if (_isMotorizingWheel) _wheelCollider.motorTorque = torque;
        }

        public void SetSteeringAngle(float angle)
        {
            if (_isSteeringWheel) _wheelCollider.steerAngle = angle;
        }

        public void SetBrakeTorque(float torque)
        {
            _wheelCollider.brakeTorque = torque;
        }

        private void UpdateWheelTransformPositionAndRotation()
        {
            Vector3 pos;
            Quaternion quat;
            _wheelCollider.GetWorldPose(out pos, out quat);
            _wheelTransform.SetPositionAndRotation(pos, quat);
        }
    }
}
