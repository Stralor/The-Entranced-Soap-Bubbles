using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReset : MonoBehaviour
{

    private Camera cam;

    void Start()
    {
        cam = Camera.main; 
    }

    void Update()
    {
        if (transform.position.y < -70) 
        {
            Reset();
        }
    }

    public void Reset()
    {
        Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
        float randomX = Random.Range(-worldPosition.x, worldPosition.x);
        transform.position = new Vector3(randomX, worldPosition.y + 10, 0);
        GetComponentInChildren<CardFlip>().Flip();
    }
}
