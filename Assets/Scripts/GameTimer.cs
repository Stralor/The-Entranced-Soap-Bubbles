using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    [SerializeField]
    private float initialTime = 3f;

    private float timeLeft = 0;
    private bool IsTimerCounting;


    public void StartTimer() 
    {
        IsTimerCounting = true;
        timeLeft = initialTime;
    }

    public void AddTime(float comboTime)
    {
        timeLeft += comboTime;
    }
    
    void Update()
    {
        int timeRounded = (int)System.Math.Round(timeLeft, 0);
        int timeClamp = timeLeft <= 0 ? 0 : timeRounded;  
        GetComponent<TMPro.TextMeshProUGUI>().text = $"TIME {timeClamp.ToString()}"; 

        if (timeLeft <= 0) 
        {
            if (IsTimerCounting && !Score.instance.HasCombo) 
            {
                IsTimerCounting = false;
                UIManager.instance.GameOver();
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    void Awake () 
    {
        instance = this;
    }
}
