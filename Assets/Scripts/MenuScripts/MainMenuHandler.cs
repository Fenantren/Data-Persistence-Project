using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject highScoreScreen;
    private bool isMainActive;
    //Start game by loading game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HighScoreMenu()
    {
        mainScreen.SetActive(false);
        isMainActive = false;

        highScoreScreen.SetActive(true);
    }
    public void BackToMenu()
    {
        if(isMainActive == false)
        {
            highScoreScreen.SetActive(false);
            
            mainScreen.SetActive(true);
            isMainActive = true;
        }
        
        
    }
}