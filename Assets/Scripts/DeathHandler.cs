using TMPro;
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

    [SerializeField]
    private TextMeshProUGUI finalScoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        // Chỉ phát âm thanh chết một lần
        if (hasPlayedDeathSound)
            return;
        hasPlayedDeathSound = true;
        gameOverCanvas.enabled = true;
        deathAudioSource.PlayOneShot(deathClip);

        // Hiển thị điểm cuối cùng
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ShowFinalScore(finalScoreText, highScoreText);
        }

        // Vô hiệu hóa vũ khí và hiển thị con trỏ chuột
        Weapon weapon = FindFirstObjectByType<Weapon>();
        if (weapon != null)
            weapon.enabled = false;
        Time.timeScale = 0;
        FindFirstObjectByType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
