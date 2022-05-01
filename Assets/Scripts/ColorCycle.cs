using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ColorCycle : MonoBehaviour
{
	public Ease ease;
	public float cycleDuration;

	public List<Color> colors = new List<Color>();

	private void Start()
	{
		var sprite = GetComponent<SpriteRenderer>();

		var sequence = DOTween.Sequence()
			.Pause()
			.SetLoops(-1)
			.SetEase(ease);

		foreach (var color in colors)
		{
			sequence.Append(sprite.DOBlendableColor(color, cycleDuration / colors.Count));
		}

		DOTween.Sequence()
			.AppendInterval(Random.Range(0, cycleDuration))
			.AppendCallback(() => sequence.Play());
	}
}
