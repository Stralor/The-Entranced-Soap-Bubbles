using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{

    void Update()
    {
        int score = Score.instance.GetScore();
        GetComponent<TMPro.TextMeshProUGUI>().text = $"Your score ${score}";
    }
}
