using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Sprites;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public int highScore;
    public string highScoreName;

    public int score2;
    public string name2;

    public int score3;
    public string name3;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScoreInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;

        public int score2;
        public string name2;

        public int score3;
        public string name3;
    }
    public void SaveScoreInfo()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        data.score2 = score2;
        data.name2 = name2;

        data.score3 = score3;
        data.name3 = name3;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScoreInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;

            score2 = data.score2;
            name2 = data.name2;

            score3 = data.score3;
            name3 = data.name3;
        }
    }
    public void ResetScoreInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = 0;
            highScoreName = null;

            score2 = 0;
            name2 = null;

            score3 = 0;
            name3 = null;

            SaveScoreInfo();
        }
    }
}
