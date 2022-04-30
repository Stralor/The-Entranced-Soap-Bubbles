using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReset : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -70) 
        {
            transform.position = new Vector3(transform.position.x,  70, 0);
        }
    }
}
