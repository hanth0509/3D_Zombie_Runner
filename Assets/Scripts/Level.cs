using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Asylum");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Sandbox");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings clicked (chưa làm)");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
