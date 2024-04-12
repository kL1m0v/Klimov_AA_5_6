using UnityEngine;
using UnityEngine.Events;

namespace Car
{
    public class FinishScript : MonoBehaviour
    {
        public UnityEvent EndRace;
        
        private void OnTriggerExit(Collider other)
        {
            EndRaceInvoke();
            gameObject.SetActive(false);
            Timer.IsTheTimerOn = false;
        }

        private void EndRaceInvoke()
        {
            EndRace?.Invoke();
        }
    }
}

