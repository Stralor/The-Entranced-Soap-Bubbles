using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ScreenStartMenu;
    [SerializeField]
    private GameObject ScreenInGame;
    [SerializeField]
    private GameObject ScreenGameOver;

    void Start() 
    {
        ScreenStartMenu.SetActive(true);
        ScreenInGame.SetActive(false);
        ScreenGameOver.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKey && ScreenStartMenu.active)
        {
            ScreenStartMenu.SetActive(false);
            ScreenInGame.SetActive(true);
            CardSpawn.instance.SpawnSwarm();
        }

        if (Input.anyKey && ScreenGameOver.active) 
        {
            ScreenStartMenu.SetActive(true);
            ScreenInGame.SetActive(false);
            CardSpawn.instance.RemoveCards();
        }
    }
}
