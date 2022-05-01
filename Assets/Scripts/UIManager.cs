using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

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
        if (Input.anyKeyDown && ScreenStartMenu.active)
        {
            ScreenStartMenu.SetActive(false);
            ScreenInGame.SetActive(true);
            ScreenGameOver.SetActive(false);
            CardSpawn.instance.SpawnSwarm();
            GameTimer.instance.StartTimer();
            Score.instance.ResetScore();
        }
        else if (Input.anyKeyDown && ScreenGameOver.active) 
        {
            ScreenStartMenu.SetActive(true);
            ScreenInGame.SetActive(false);
            ScreenGameOver.SetActive(false);
            CardSpawn.instance.RemoveCards();
        }
    }

    public void GameOver()
    {
        ScreenStartMenu.SetActive(false);
        ScreenInGame.SetActive(false);
        ScreenGameOver.SetActive(true);
    }

    void Awake () 
    {
        instance = this;
    }
}
