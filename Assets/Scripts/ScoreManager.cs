using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public string PlayerName = "";
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
    }
}
