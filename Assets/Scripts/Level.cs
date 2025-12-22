using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip levelMusic;

    private void Start()
    {
        // Tự động tìm AudioSource nếu chưa gán
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        // Phát nhạc level
        PlayLevelMusic();
    }

    private void PlayLevelMusic()
    {
        if (audioSource != null && levelMusic != null)
        {
            audioSource.clip = levelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

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
