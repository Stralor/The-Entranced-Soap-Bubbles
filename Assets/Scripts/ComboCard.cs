using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ComboCard : MonoBehaviour
{
    public void Clear(float delay)
    {
        var image = GetComponent<Image>();
        DOTween.Sequence()
            .AppendInterval(delay)
            .Append(image.DOFade(0, 1))
            .AppendCallback(() => gameObject.SetActive(false));
    }
}
