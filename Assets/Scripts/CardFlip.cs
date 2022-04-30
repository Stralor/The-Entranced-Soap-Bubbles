using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public Vector2 durationRange;
    public Vector2 intervalRange;

    private float duration;
    private float interval;

    private Sequence flipSequence;
    
    void Start()
    {
        duration = Random.Range(durationRange.x, durationRange.y);
        interval = Random.Range(intervalRange.x, intervalRange.y);

        DOTween.Sequence()
            .AppendInterval(Random.Range(0, interval))
            .AppendCallback(() => flipSequence = Flip());
    }
    
    public Sequence Flip()
    {
        if (flipSequence != null && flipSequence.IsPlaying())
        {
            return flipSequence;
        }
        
        return DOTween.Sequence()
            .Append(transform.DOLocalRotate(new Vector3(0, 180, 0), duration)
                .SetEase(Ease.InOutBack))
            .AppendInterval(interval)
            .SetLoops(-1, LoopType.Incremental);
    }

    public void Pause()
    {
        flipSequence?.Pause();
    }

    public void Resume()
    {
        flipSequence?.Play();
    }

    public Tween Stop()
    {
        flipSequence?.Kill();

        return transform.DORotate(new Vector3(0, 0, 0), 0.3f)
            .SetEase(Ease.OutBounce);
    }
}
