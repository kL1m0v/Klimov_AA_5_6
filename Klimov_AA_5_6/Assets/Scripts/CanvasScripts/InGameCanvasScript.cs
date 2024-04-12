using TMPro;

namespace Car
{
    public class InGameCanvasScript : CanvasScript
    {
        private TextMeshProUGUI _time;

        protected override void Awake()
        {
            base.Awake();
            _time = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            _time.text = Timer.TimeInString;
        }

        public override void ShowCanvas()
        {
            base.ShowCanvas();
            Timer.IsTheTimerOn = true;
        }
    }
}