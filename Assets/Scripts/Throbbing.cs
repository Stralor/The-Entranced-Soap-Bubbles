using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Shapes;

public class Throbbing : MonoBehaviour
{
    public float minRadius;
    public float maxRadius;
    public float duration;

    private Disc disc;
    private float baseRadius;

    private bool upThrobbing = false;

    void Start()
    {
        disc = GetComponent<Disc>();
        baseRadius = disc.Radius;
    }

    public void Down()
    {
        var downThrob = DOTween.Sequence()
            .Append(DOTween.To(
                    () => disc.Radius,
                    x => disc.Radius = x,
                    minRadius, duration)
                .SetEase(Ease.OutElastic));
    }

    public void Up()
    {
        upThrobbing = true;
        
        var upThrob = DOTween.Sequence()
            .Append(DOTween.To(
                    () => disc.Radius,
                    x => disc.Radius = x,
                    maxRadius, duration)
                .SetEase(Ease.OutElastic))
            .AppendCallback(() => upThrobbing = false)
            .AppendCallback(() => Reset());
    }

    public void Reset()
    {
        if (!upThrobbing)
        {
            var reset = DOTween.Sequence()
                .Append(DOTween.To(
                        () => disc.Radius,
                        x => disc.Radius = x,
                        baseRadius, duration)
                    .SetEase(Ease.OutElastic));
        }
    }
}
