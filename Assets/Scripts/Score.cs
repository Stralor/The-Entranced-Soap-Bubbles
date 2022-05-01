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
        if (combos.Count > 0)
        {
            // Compare current card to the one added latest
            if (IsValidForCombo(cardName))
            {
                CardData lastCombo = combos[combos.Count - 1];
                // Change this calculation to whatever
                scoreValue += lastCombo.CardValue * value;
            }
            else
            {
                // Remove all combos
                combos.Clear();
                ComboSpawner.instance.ClearCombo();
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

    public bool IsValidForCombo(string cardName)
    {
        if (combos.Count > 0) 
        {
            CardData lastCombo = combos[combos.Count - 1];
            if (lastCombo.CardName == cardName)
            {
                return true;// Change this calculation to whatever
            }
            else
            {
                return false;
            }
        }

        return true;
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