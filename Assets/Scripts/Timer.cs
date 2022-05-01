using DG.Tweening;
using Shapes;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public float lifetime;

	public UnityEvent OnTimerEnd;

	private Disc disc;
	private float angStart;
	private Sequence lifeTimer;
	
	
	void Start()
	{
		disc = GetComponent<Disc>();
		angStart = disc.AngRadiansStart;
	}

	void StartTimer()
	{
		lifeTimer = DOTween.Sequence()
			.AppendInterval(lifetime/10)
			.Append(DOTween.To(
					() => disc.AngRadiansEnd,
					x => disc.AngRadiansEnd = x,
					angStart + ShapesMath.TAU,
					lifetime)
				.SetEase(Ease.InOutSine))
			.AppendInterval(lifetime/10)
			.AppendCallback(() => OnTimerEnd?.Invoke());
	}

	public void Reset()
	{
		lifeTimer?.Kill();
		
		disc.AngRadiansEnd = disc.AngRadiansStart;
		
		StartTimer();
	}
}