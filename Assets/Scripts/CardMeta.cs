using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMeta : MonoBehaviour
{
    public string Name;
    public int ScoreValue = 0;

    [HideInInspector] public Sprite sprite;

    [HideInInspector] public Color color;
}
