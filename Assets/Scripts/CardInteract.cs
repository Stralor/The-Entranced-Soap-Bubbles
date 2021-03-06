using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CardInteract : MonoBehaviour {
    private Plane dragPlane;

    private Vector3 offset;

    private Camera myMainCamera;

    void Start()
    {
        myMainCamera = Camera.main; 
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    void OnMouseUpAsButton()
    {
        var meta = GetComponent<CardMeta>();
        
        Tween sendTween;
        
        if (Score.instance.IsValidForCombo(meta.Name))
        {
            sendTween = ComboSpawner.instance.SendCardToLastOfCombo(transform);
        }
        else
        {
            sendTween = DOTween.Sequence()
                .Append(transform.DOLocalMove(Vector3.up, 0.1f))
                .Insert(0, transform.DOScale(Vector3.zero, 0.1f))
                .Insert(0, transform.GetComponentInChildren<SpriteRenderer>().DOFade(0, 0.1f));
        }

        DOTween.Sequence()
            .Append(GetComponentInChildren<CardFlip>().Stop())
            .Append(sendTween)
            .AppendCallback(() => GetComponent<CardReset>().Reset())
            .AppendCallback(() => ComboSpawner.instance.Spawn(GetComponent<CardMeta>()))
            .AppendCallback(() => {
                // Add score
                Score.instance.AddScore(meta.Name, GetComponent<CardMeta>().ScoreValue);
            });
    }

    // void OnMouseDrag()
    // {   
    //     Debug.Log("OnMouseDrag");
    //     Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 
    //     float planeDist;
    //     dragPlane.Raycast(camRay, out planeDist);
    //     transform.position = camRay.GetPoint(planeDist) + offset;
    // }
}