using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Biến tĩnh để truy cập từ mọi nơi trong game
    public static ScoreManager Instance { get; private set; }

    // UI Text để hiển thị điểm
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI finalScoreText;

    [SerializeField]
    private int currentScore = 0;

    [SerializeField]
    private const string HighScoreKey = "HighScore";

    // Khởi tạo singleton pattern
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Hàm thêm điểm
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    // Cập nhật giao diện điểm số
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }
        Debug.Log($"Current Score: {currentScore}");
    }

    // Hiển thị điểm cuối cùng khi chết
    public void ShowFinalScore(TextMeshProUGUI finalScoreText, TextMeshProUGUI highScoreText = null)
    {
        SaveHighScore();
        if (finalScoreText != null)
        {
            finalScoreText.text = $"Score: {currentScore}";
            finalScoreText.gameObject.SetActive(true); // Đảm bảo text được hiển thị
        }
        Debug.Log($"Final Score: {currentScore}");
        if (highScoreText != null)
        {
            highScoreText.text = $"High Score: {GetHighScore()}";
            highScoreText.gameObject.SetActive(true);
        }
    }

    private void SaveHighScore()
    {
        // Lưu điểm cao nhất sử dụng PlayerPrefs
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (currentScore > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, currentScore);
            PlayerPrefs.Save();
            Debug.Log("Save NewHigh Score: " + currentScore);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    // Đặt lại điểm số
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}
