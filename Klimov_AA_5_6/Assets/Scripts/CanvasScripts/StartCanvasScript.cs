using Car;
using UnityEngine;
using UnityEngine.Events;

public class StartCanvasScript : CanvasScript
{
    private Animation _rippleAnimation;
    private CountdownAnimationEvents _countdownAnimationEvents;

    public UnityEvent RaceHasStarted;

    protected override void Awake()
    {
        base.Awake();
        _rippleAnimation = GetComponentInChildren<Animation>();
        _countdownAnimationEvents = GetComponentInChildren<CountdownAnimationEvents>();
        _countdownAnimationEvents.RaceHasStarted.AddListener(StartRace);

    }
    
    public override void ShowCanvas()
    {
        base.ShowCanvas();
        _rippleAnimation.Play();
    }

    private void StartRace()
    {
        RaceHasStarted?.Invoke();
        HideCanvas();
    }
}
