using UnityEngine;

public class Audio : MonoBehaviour
{
 [Header("Âm thanh")]
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip sandboxMusic;

    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        PlayMusic();
    }

    private void PlayMusic()
    {
        if (audioSource != null && sandboxMusic != null)
        {
            audioSource.clip = sandboxMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
