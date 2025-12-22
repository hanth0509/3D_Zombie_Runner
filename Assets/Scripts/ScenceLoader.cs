using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoader : MonoBehaviour
{
    // Tải lại scene hiện tại
    public void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Về màn hình chính
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
