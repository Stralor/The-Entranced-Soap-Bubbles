using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject playUI;
    [SerializeField] GameObject gameOverUI;


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() // NOT BEING USED YET
    {
        startMenu.SetActive(false);
        playUI.SetActive(true);
    }
}
