using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Car
{
     public class CountdownAnimationEvents : MonoBehaviour
    {
        private TextMeshProUGUI _countDownText;
        private float _countDownTime = 3;
        public UnityEvent RaceHasStarted;

        private void Awake()
        {
            _countDownText = GetComponent<TextMeshProUGUI>();
            _countDownText.text = _countDownTime.ToString();
        }

        private void CountDownAnimationEvent()
        {
            _countDownTime--;
            _countDownText.text = _countDownTime.ToString();
            if (_countDownTime == 0)
            {
                _countDownText.text = "Start";
                StartCoroutine(Delay());
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(1f);
            RaceHasStarted?.Invoke();
        }
    }
}
