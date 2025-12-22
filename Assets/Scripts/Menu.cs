using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public GameObject startButton;
    public GameObject settingButton;
    public GameObject quitButton;

    [Header("Panels")]
    public GameObject settingsPanel;

    private void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void OpenSettings()
    {
        // Ẩn menu chính
        startButton.SetActive(false);
        settingButton.SetActive(false);
        quitButton.SetActive(false);

        // Hiện panel settings
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        // Hiện lại menu chính
        startButton.SetActive(true);
        settingButton.SetActive(true);
        quitButton.SetActive(true);

        // Ẩn settings
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
