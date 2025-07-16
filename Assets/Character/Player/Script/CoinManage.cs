using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int coins = 0;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        // Singleton check
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Uang ditambahkan: " + amount + " | Total sekarang: " + coins);
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins.ToString("N0");
        }
        else
        {
            Debug.LogWarning("Coin Text belum di-assign di Inspector!");
        }
    }
}
