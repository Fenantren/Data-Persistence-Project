using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HiScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = $"{ScoreManager.Instance.highScore}";
    }

}
