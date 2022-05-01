using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    private int scoreValue = 0;

    private List<CardData> combos = new List<CardData>();

    public void AddScore(string cardName, int value) 
    {
        // Compare current card to the one added latest
        if (combos.Count > 0) 
        {
            CardData lastCombo = combos[combos.Count - 1];
            if (lastCombo.CardName == cardName) 
            {
                // Change this calculation to whatever
                scoreValue += lastCombo.CardValue * value; 
            }
            else 
            {
                // Remove all combos
                combos.Clear();
            }
        }

        // If no combos - just add up 
        if (combos.Count <= 0) 
        {
            scoreValue += value;
        }

        // Update text
        GetComponent<TMPro.TextMeshProUGUI>().text = $"SCORE {scoreValue.ToString()}";

        // Remember combos 
        combos.Add(new CardData() { 
            CardName = cardName,
            CardValue = value
        });
    }

    void Awake()
    {
        instance = this;
    }
}


public class CardData
{
    public string CardName;
    public int CardValue;
}