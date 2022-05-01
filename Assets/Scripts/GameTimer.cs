using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private float time = 3f;
    
    void Update()
    {
        int timeRounded = (int)System.Math.Round(time, 0);
        int timeClamp = time <= 0 ? 0 : timeRounded;  
        GetComponent<TMPro.TextMeshProUGUI>().text = $"TIME {timeClamp.ToString()}";

        if (time <= 0) return;
        time -= Time.deltaTime;
    }
}
