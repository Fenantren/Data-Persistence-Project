using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject highScoreScreen;
    private bool isMainActive;

    private void Awake()
    {
        ScoreManager.Instance.LoadScoreInfo();
    }
    //Start game by loading game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //Enables the High Score screen
    public void HighScoreMenu()
    {
        mainScreen.SetActive(false);
        isMainActive = false;

        highScoreScreen.SetActive(true);
    }
    // Disables High Score screen and enables Main Menu
    public void BackToMenu()
    {
        if(isMainActive == false)
        {
            highScoreScreen.SetActive(false);
            
            mainScreen.SetActive(true);
            isMainActive = true;
        }
        
    }
    public void ResetScoreList()
    {
        ScoreManager.Instance.ResetScoreInfo();
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
        
    }
        
}