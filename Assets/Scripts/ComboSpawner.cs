using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Mono.Cecil.Cil;
using UnityEngine.UI;

public class ComboSpawner : MonoBehaviour
{
    public static ComboSpawner instance;
    
    public GameObject comboCardPrefab;
    
    public List<GameObject> comboCards = new List<GameObject>();

    private List<GameObject> comboCardPool = new List<GameObject>();
    
    private static float claimDuration = 0.3f;
    
    public void Spawn(CardMeta metaData)
    {
        var card = GetCard();
        
        comboCards.Add(card);
        
        var image = card.GetComponent<Image>();
        image.sprite = metaData.sprite;
        image.color = metaData.color;
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

    public Tween SendCardToLastOfCombo(Transform t)
    {
        if (comboCards.Count == 0)
        {
            return DOTween.Sequence()
                .Append(t.DOLocalMove(Vector3.up, claimDuration/2))
                .Insert(0, t.DOScale(Vector3.zero, claimDuration/2))
                .Insert(0, t.GetComponentInChildren<SpriteRenderer>().DOFade(0, claimDuration/2));
        }

        var rect = comboCards.Last().GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);
        var averageX = corners.Select(val => val.x).Average();
        var averageY = corners.Select(val => val.y).Average();
        var averageZ = corners.Select(val => val.z).Average();
        var average = new Vector3(averageX, averageY, averageZ);

        t.GetComponentInChildren<SpriteRenderer>().sortingOrder = 11;
        
        return t.DOMove(average, claimDuration);
    }
    
    void Awake()
    {
        instance = this;
    }
}
