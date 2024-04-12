using UnityEngine;

namespace Car
{
    public class WheelsController : MonoBehaviour
    {
        private WheelComponent[] _wheelsComponents;

        [SerializeField]
        private float _maxTorque = 1500f;
        [SerializeField]
        private float _minTorque = -10f;
        [SerializeField]
        private float _speedFactor = 10f;
        [SerializeField]
        private float _maxSteeringAngle = 30f;
        [SerializeField]
        private float _brakeFactor = 2000f;

        private float _currentTorque = 0;
        private float _currentSteeringAngle = 0;

        private void Awake()
        {
            _wheelsComponents = GetComponentsInChildren<WheelComponent>();
        }

        public void SetMotorTorqueForMotorizedWheels(float inputValue)
        {
            if(inputValue != 0) 
            {
                _currentTorque += inputValue * _speedFactor;
                _currentTorque = Mathf.Clamp(_currentTorque, _minTorque, _maxTorque);
            }
            else
            {
                _currentTorque = 0;
            }
            
            foreach(WheelComponent wheel in _wheelsComponents) 
            {
                wheel.SetMotorTorque(_currentTorque);
            }
        }

        public void SetSteerAngleForSteeringWheels(float input)
        {
            if(input > 0) _currentSteeringAngle = Mathf.Lerp(0, _maxSteeringAngle, Time.fixedTime);
            else if(input < 0) _currentSteeringAngle = Mathf.Lerp(0, -_maxSteeringAngle, Time.fixedTime);
            else _currentSteeringAngle = 0;

            foreach (WheelComponent wheel in _wheelsComponents)
            {
                wheel.SetSteeringAngle(_currentSteeringAngle);
            }
        }

        public void AddBreakTorque(float torque)
        {
            foreach (WheelComponent wheel in _wheelsComponents)
            {
                wheel.SetBrakeTorque(torque * _brakeFactor);
            }
        }
    }
}
