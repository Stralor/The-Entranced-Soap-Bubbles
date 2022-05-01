using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    private int scoreValue = 0;

    public void AddScore(string cardName, int value) 
    {
        scoreValue += value;
        GetComponent<TMPro.TextMeshProUGUI>().text = $"SCORE {scoreValue.ToString()}";
    }

    void Awake()
    {
        instance = this;
    }
}
