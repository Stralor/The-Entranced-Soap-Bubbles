using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour
{

    [SerializeField]
    GameObject CardPrefab;

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
        if (IsSpawnedInView) 
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 100f);
            Instantiate(CardPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity, transform);
        } 
        else 
        {
            float randomX = Random.Range(-100f, 100f);
            Instantiate(CardPrefab, new Vector3(randomX, 70, 0), Quaternion.identity, transform);
        }
    }
}
