using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CardInteract : MonoBehaviour {
    private Plane dragPlane;

    private Vector3 offset;

    private Camera myMainCamera;

    private static float claimDuration = 0.3f;

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

        Debug.Log("OnMouseDown");
    }

    void OnMouseUpAsButton()
    {
        var destiny = ComboSpawner.instance.GetWorldPositionOfLastComboCard();
        
        DOTween.Sequence()
            .Append(GetComponentInChildren<CardFlip>().Stop())
            .Append(DOTween.To(
                () => transform.position,
                x => transform.position = x,
                destiny,
                claimDuration))
            .AppendCallback(() => GetComponent<CardReset>().Reset())
            .AppendCallback(() => ComboSpawner.instance.Spawn());
    }

    void OnMouseDrag()
    {   
        Debug.Log("OnMouseDrag");
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 
        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }
}