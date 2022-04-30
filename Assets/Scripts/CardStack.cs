using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardStack : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Image card;
    [SerializeField]
    private float size = 100;
    [SerializeField]
    private float offset = 8f;
    [SerializeField]
    private List<string> cardTypes = new List<string>() { "McFart" };
    private List<Image> Stack = new List<Image>(); 


    public void Start () 
    {
        for (int i=0; i < size; i++) 
        {
            Vector3 cardOffset = new Vector3(i * offset, -i * offset, 0);
            AddCard(transform.position + cardOffset);
        }
    }

    public void AddCard (Vector3 cardPosition) 
    {
        Image cardInstance = Instantiate(card, cardPosition, Quaternion.identity, canvas.transform) as Image;
        cardInstance.GetComponent<CardType>().Type = cardTypes[0];
        Stack.Add(cardInstance);
    }

}
