using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComboSpawner : MonoBehaviour
{
    public static ComboSpawner instance;
    
    public GameObject comboCardPrefab;
    
    public List<GameObject> comboCards = new List<GameObject>();

    private List<GameObject> comboCardPool = new List<GameObject>();
    
    public void Spawn()
    {
        var card = GetCard();
        
        comboCards.Add(card);
    }

    public void ClearCombo()
    {
        comboCards.ForEach(card => card.SetActive(false));
        comboCardPool.AddRange(comboCards);
        comboCards.Clear();
    }

    private GameObject GetCard()
    {
        GameObject card;
        
        if (comboCardPool.Count > 0)
        {
            card = comboCardPool.First();
            comboCardPool.Remove(card);
            
            card.SetActive(true);
        }
        else
        {
            card = Instantiate(comboCardPrefab, transform);
        }

        card.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-15, 15));

        return card;
    }

    public Vector3 GetWorldPositionOfLastComboCard()
    {
        if (comboCards.Count == 0)
        {
            return transform.position;
        }

        var rect = comboCards.Last().GetComponent<RectTransform>();
        return rect.position;
    }
    
    void Awake()
    {
        instance = this;
    }
}
