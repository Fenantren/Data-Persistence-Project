using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuHandler : MonoBehaviour
{
    //Start game by loading game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}