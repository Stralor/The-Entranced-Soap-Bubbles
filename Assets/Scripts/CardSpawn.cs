using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class CardSpawn : MonoBehaviour
{
    public static CardSpawn instance;

    [SerializeField]
    GameObject CardPrefab;
    
    public List<Sprite> cards;
    
    public List<Color> colors = new List<Color>();
    
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


    private Camera cam;

    void Start()
    {
        cam = Camera.main; 

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
        int cardIndex = Random.Range(0, cards.Count);
        if (cardIndex < 0) return;

        Sprite cardSprite = cards[cardIndex];

        // Spawn inside / outside viewport
        Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
        float randomX = Random.Range(-worldPosition.x, worldPosition.x); 
        float randomY = (IsSpawnedInView ? Random.Range(-worldPosition.y, worldPosition.y) : worldPosition.y) + 10;

        // Spawn
        GameObject card = Instantiate(CardPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity, transform);
        card.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-5, 5);

        // Meta
        int value = Random.Range(MinScore, MaxScore);
        var cardMeta = card.GetComponent<CardMeta>();
        cardMeta.Name = cardSprite.name;
        cardMeta.ScoreValue = value;
        cardMeta.sprite = cardSprite;
        cardMeta.color = colors[cardIndex];
        
        // Display text on card
        card.GetComponentsInChildren<TMPro.TextMeshPro>().ToList().ForEach(text => text.text = $"{value.ToString()}");

        // Apply texture
        var spriteRenderer = card.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = cardMeta.sprite;
        spriteRenderer.color = cardMeta.color;

    }

    private void Awake()
    {
        instance = this;
    }
}
