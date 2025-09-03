using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    
    // Proměnná pro uložení textu z InputField
    private string playerName = "";
    
    void Start()
    {
        // Nastav event listener pro TMP InputField
        if (playerNameInput != null)
        {
            playerNameInput.onValueChanged.AddListener(OnPlayerNameChanged);
            Debug.Log("Event listener nastaven na TMP InputField");
        }
        else
        {
            Debug.LogError("playerNameInput není přiřazen!");
        }
    }
    
    public void OnPlayerNameChanged(string newValue)
    {
        playerName = newValue;
        Debug.Log("PlayerName: " + playerName);
        ScoreManager.Instance.PlayerName = playerName;
    }
    
    public void Play()
    {
        SceneManager.LoadScene("main");
    }
    
    public void Quit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
