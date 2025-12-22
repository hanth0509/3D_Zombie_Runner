using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField]
    Canvas gameOverCanvas;

    [SerializeField]
    private AudioSource deathAudioSource;

    [SerializeField]
    private AudioClip deathClip;
    private bool hasPlayedDeathSound = false;

    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        if (hasPlayedDeathSound)
            return;
        hasPlayedDeathSound = true;
        gameOverCanvas.enabled = true;
        deathAudioSource.PlayOneShot(deathClip);

        Weapon weapon = FindFirstObjectByType<Weapon>();
        if (weapon != null)
            weapon.enabled = false;
        Time.timeScale = 0;
        FindFirstObjectByType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
