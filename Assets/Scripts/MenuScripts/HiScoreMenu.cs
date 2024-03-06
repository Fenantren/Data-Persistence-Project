using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HiScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highScoreName;

    public TextMeshProUGUI score2;
    public TextMeshProUGUI scoreName2;

    public TextMeshProUGUI score3;
    public TextMeshProUGUI scoreName3;

    private void Update()
    {
        highScore.text = ScoreManager.Instance.highScore.ToString();
        highScoreName.text = ScoreManager.Instance.highScoreName;

        score2.text = ScoreManager.Instance.score2.ToString();
        scoreName2.text = ScoreManager.Instance.name2;

        score3.text = ScoreManager.Instance.score3.ToString();
        scoreName3.text = ScoreManager.Instance.name3;

    }










}
