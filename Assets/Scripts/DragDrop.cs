using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool isDraggingAllowed = true;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake () 
    {
        if (!isDraggingAllowed) return;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag (PointerEventData eventData) 
    {
        if (!isDraggingAllowed) return;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag (PointerEventData eventData) 
    {
        if (!isDraggingAllowed) return;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag (PointerEventData eventData) 
    {
        canvasGroup.alpha = 1.0f;
        if (!isDraggingAllowed) return;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown (PointerEventData eventData) 
    {
        // Debug.Log("OnPointerDown");
    }
}
