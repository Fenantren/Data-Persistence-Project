using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HiScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerName;

    private void Awake()
    {
        scoreText.text = $"{ScoreManager.Instance.highScore}";
        playerName.text = $"{ScoreManager.Instance.player}";
    }

}
