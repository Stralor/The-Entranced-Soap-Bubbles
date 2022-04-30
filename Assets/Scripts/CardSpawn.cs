using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour
{

    [SerializeField]
    GameObject CardPrefab;

    [SerializeField]
    List<Sprite> cards;

    [SerializeField]
    int MinScore = -1;

    [SerializeField]
    int MaxScore = 10;

    [SerializeField]
    int InitialAmount = 10;

    [SerializeField]
    int MaxAmount = 50;

    [SerializeField]
    float Interval = .5f;

    float Timer = 0;


    void Start()
    {
        for (int i=0; i < InitialAmount; i++) 
        {
            AddCard(true);
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > Interval && transform.childCount < MaxAmount) 
        {
            Timer = 0;
            AddCard();
        }
    }


    public void AddCard (bool IsSpawnedInView = false) 
    {
        if (cards.Count == 0) 
        {
            Debug.Log("No card texture added.");
            return;
        }

        // Pick random card
        int cardIndex = Random.Range(0, cards.Count - 1);
        if (cardIndex < 0) return;

        Sprite cardSprite = cards[cardIndex];

        // Spawn inside / outside viewport
        float randomX = Random.Range(-100f, 100f);
        float randomY = IsSpawnedInView ? Random.Range(-100f, 100f) : 70;

        // Spawn
        GameObject card = Instantiate(CardPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity, transform);

        // Meta
        card.GetComponent<CardMeta>().Name = cardSprite.name;
        card.GetComponent<CardMeta>().ScoreValue = Random.Range(MinScore, MaxScore);
        
        // Apply texture
        card.GetComponentInChildren<SpriteRenderer>().sprite = cardSprite;
    }
}
