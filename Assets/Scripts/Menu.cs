using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
     public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings clicked (chưa làm)");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
