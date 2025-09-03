using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public string PlayerName = "";
    public Text HighScoreText;
    public static ScoreManager Instance;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
        HighScoreText.text = $"High Score : " + $"{PlayerName} {highScore}";
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }
    public void SaveScore(){
        if (score > highScore){
            SaveData data = new SaveData();
            data.highScore = score;
            data.playerName = PlayerName;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
    public void LoadScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            PlayerName = data.playerName;
        }
    }
}
