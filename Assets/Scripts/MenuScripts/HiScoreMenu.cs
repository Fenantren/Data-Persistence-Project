using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HiScoreMenu : MonoBehaviour
{
    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI playerName;
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("scoreEntryContainer");
        entryTemplate = entryContainer.Find("scoreEntryTemplate");
        //scoreText.text = $"{ScoreManager.Instance.highScore}";
        //playerName.text = $"{ScoreManager.Instance.player}";

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        
        for (int i = 1; i < 7; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition =  new Vector2(-5, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
    //public void NewScoreAdd()
    
    

}
