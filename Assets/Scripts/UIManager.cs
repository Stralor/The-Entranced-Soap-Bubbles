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
    [SerializeField]
    private GameObject ButtonStartGame;


    void Update()
    {
        if (Input.anyKey && ScreenStartMenu.active)
        {
            ScreenStartMenu.SetActive(false);
            ScreenInGame.SetActive(true);
        }

        if (Input.anyKey && ScreenGameOver.active) 
        {
            ScreenStartMenu.SetActive(true);
            ScreenInGame.SetActive(false);
        }
    }
}
