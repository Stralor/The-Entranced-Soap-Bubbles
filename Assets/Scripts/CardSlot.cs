using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CardSlot : MonoBehaviour, IDropHandler
{
    private List<string> cards = new List<string>();

    public void OnDrop(PointerEventData eventData) 
    {
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            string type = eventData.pointerDrag.GetComponent<CardType>().Type;

            // Remember stacked cards
            cards.Add(type);

            // Disable drag/drop
            eventData.pointerDrag.GetComponent<DragDrop>().isDraggingAllowed = false;

            Debug.Log("Stacked cards: " + string.Join(", ", cards.ToArray()));
        }
    }

}