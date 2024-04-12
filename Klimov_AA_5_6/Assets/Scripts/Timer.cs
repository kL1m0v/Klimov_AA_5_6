using System.Collections;
using UnityEngine;

namespace Car
{
    public class Timer : MonoBehaviour
    {
        private static Timer _timer;
        
        private static float _timeInSeconds;
        private static string _timeInString;
        private static bool isTheTimerOn = false;

        public static string TimeInString { get => _timeInString; }
        public static bool IsTheTimerOn { get => isTheTimerOn; set => isTheTimerOn = value; }

        private void Awake()
        {
            if( _timer != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _timer = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Update()
        {
            if (IsTheTimerOn)
            {
                TimeCounting();
            }
        }

        private void TimeCounting()
        {
            _timeInSeconds += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(_timeInSeconds % 60);
            int milliseconds = Mathf.FloorToInt((_timeInSeconds * 10) % 10);
            _timeInString = string.Format("{0:00}:{1:00}:{2:0}", minutes, seconds, milliseconds);
        }
    }
}
