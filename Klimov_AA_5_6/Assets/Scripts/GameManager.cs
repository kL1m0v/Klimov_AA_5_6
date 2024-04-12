using UnityEngine;

namespace Car
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CarController _car;
        [SerializeField]
        private StartCanvasScript _startCanvas;
        [SerializeField]
        private InGameCanvasScript _inGameCanvas;
        [SerializeField]
        private FinishCanvasScript _finishCanvas;
        [SerializeField]
        private FinishScript _finishScript;

        private void Start()
        {
            _startCanvas.RaceHasStarted.AddListener(StartRace);
            _startCanvas.ShowCanvas();
            _finishScript.EndRace.AddListener(EndRace);
        }

        private void StartRace()
        {
            _car.CanMove = true;
            _inGameCanvas.ShowCanvas();
        }

        private void EndRace()
        {
            _car.CanMove = false;
            _inGameCanvas.HideCanvas();
            _finishCanvas.ShowCanvas();
        }

    }
}
