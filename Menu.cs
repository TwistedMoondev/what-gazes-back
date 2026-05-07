using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button button;
    //private GameManagerX gameManagerX;

    [Header("Screens")]
    public GameObject titleScreen;
    public GameObject settingsScreen;
    public GameObject deathScreen;
    public GameObject runStartScreen;
    public GameObject puaseScreen;
    //public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);


    }

    void GameState(int gameState)
    {
        if (gameState == 0) {
            //title screen
            ScreenShift(true, false, false, false, false);
           
        } else if (gameState == 1) {
            //settings screen

            ScreenShift(false, true, false, false, false);

        } else if (gameState == 2) {
            //during the game

            ScreenShift(false, false, false, false, false);
            
        } else if (gameState == 3) {
            // death screen

            ScreenShift(false, false, true, false, false);
            
        } else if (gameState == 4) {
            // puase screen

            ScreenShift(false, false, false, false, true);
            
        }else if (gameState == 5) {
            // run start screen

            ScreenShift(false, false, false, true, false);
            
        }
    }

    void ScreenShift(bool title, bool settings, bool death, bool runStart, bool puase)
    {
        titleScreen.SetActive(title); 
        settingsScreen.SetActive(settings); 
        deathScreen.SetActive(death); 
        runStartScreen.SetActive(runStart); 
        puaseScreen.SetActive(puase); 
    }

    
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        //gameManager.StartGame();
    }



}
