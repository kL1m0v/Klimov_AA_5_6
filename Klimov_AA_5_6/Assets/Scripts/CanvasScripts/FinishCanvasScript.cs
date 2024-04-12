using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Car
{
    public class FinishCanvasScript : CanvasScript
    {
        [SerializeField]
        private TextMeshProUGUI[] _bestTimeText;
        private Canvas _rootCanvas;
        [SerializeField]
        private Canvas _canvasWithBestRaces;
        private TMP_InputField _inputField;

        protected override void Awake()
        {
            base.Awake();
            _inputField = GetComponentInChildren<TMP_InputField>();
            _rootCanvas = GetComponent<Canvas>();
            GetComponent<Canvas>().enabled = false;
            _inputField.onEndEdit.AddListener(ShowResults);
        }

        public void ShowResults(string name)
        {
            ResultHandler.WriteResult(name, Timer.TimeInString);
            _rootCanvas.enabled = true;
            _canvasWithBestRaces.enabled = true;
            Debug.Log(_canvasWithBestRaces.enabled);
            ResultHandler.FillResultLines(_bestTimeText);
            _inputField.gameObject.SetActive(false);
        }
    }
}
