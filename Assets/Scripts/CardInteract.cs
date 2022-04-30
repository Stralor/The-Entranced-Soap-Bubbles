using UnityEngine;
using System.Collections;

public class DragDrop2D : MonoBehaviour {
    // private Plane dragPlane;

    // private Vector3 offset;

    // private Camera myMainCamera; 

    // void Start()
    // {
    //     myMainCamera = Camera.main; 
    // }

    // void OnMouseDown()
    // {
    //     dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
    //     Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

    //     float planeDist;
    //     dragPlane.Raycast(camRay, out planeDist); 
    //     offset = transform.position - camRay.GetPoint(planeDist);
    // }

    // void OnMouseDrag()
    // {   
    //     Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

    //     float planeDist;
    //     dragPlane.Raycast(camRay, out planeDist);
    //     transform.position = camRay.GetPoint(planeDist) + offset;
    // }
}