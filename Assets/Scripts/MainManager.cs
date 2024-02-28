using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;
    public GameObject PlayerNameInput;
    public TextMeshProUGUI PlayerInputText;

    private bool m_Started = false;
    private int m_highScore;
    private int m_Points;

    private bool m_GameOver = false;


   
    private void Awake()
    {
        //Allows to see current session's high score upon reloading (new game) 
        HighScoreText.text = $"High Score : {ScoreManager.Instance.highScore}";
        
    }
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
                
            }
        }
    }

    private void Update()
    {
        HighScore();
       
        if (!m_Started)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
       
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        
        
    }
    //Updates the high score in comparison to current score and stores it  (used in Update method) 
    void HighScore()
    {
        
        if (m_Points >= ScoreManager.Instance.highScore)
        {
            m_highScore = m_Points;
            HighScoreText.text = $"High Score : {m_highScore}";
            ScoreManager.Instance.highScore = m_highScore;
        }
        else if (m_Points < ScoreManager.Instance.highScore)
        {
            m_highScore = ScoreManager.Instance.highScore;
        }
        
    }
    
   
    public void GameOver()
    {
        
        PlayerNameInput.SetActive(true);
    }
    public void InstructionLoad()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        
        if(m_Points >= ScoreManager.Instance.highScore)
        {
            ScoreManager.Instance.player = PlayerInputText.text;
        }
        
        PlayerNameInput.SetActive(false);
    }
}
