using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip menuMusic;

    private void Start()
    {
        // Tự động tìm AudioSource nếu chưa gán
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        // Phát nhạc menu
        PlayMenuMusic();
    }

    private void PlayMenuMusic()
    {
        if (audioSource != null && menuMusic != null)
        {
            audioSource.clip = menuMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

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
