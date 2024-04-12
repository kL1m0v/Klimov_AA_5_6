using UnityEngine;

public abstract class CanvasScript : MonoBehaviour
{
    private Canvas _canvas;

    protected virtual void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public virtual void ShowCanvas()
    {
        _canvas.enabled = true;
    }

    public void HideCanvas()
    {
        _canvas.enabled = false;
    }
}
