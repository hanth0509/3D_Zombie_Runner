using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoader : MonoBehaviour
{
    public void ReadLoadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
