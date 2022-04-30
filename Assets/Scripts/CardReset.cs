using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReset : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -70) 
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(transform.position.x,  70, 0);
        GetComponentInChildren<CardFlip>().Flip();
    }
}
