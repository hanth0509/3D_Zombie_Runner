using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float hitPoints = 100f;

    [SerializeField]
    private TextMeshProUGUI healthText;

    private void Start()
    {
        UpdateHealthPlay();
    }

    private void UpdateHealthPlay()
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {Mathf.Max(0, hitPoints)}"; // Hiển thị máu
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        UpdateHealthPlay();
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
