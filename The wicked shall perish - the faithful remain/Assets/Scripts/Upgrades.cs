using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI incomeInfoText;

    [Header("Generator values")]
    public int startPrice = 20;
    public float upgradePriceMultiplier;
    public float FaithPerUpgrade = 0.1f;

    [Header("Managers")]
    public GameManager gameManager;
    int level = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void ClickUpgrade()
    {
        int price = CalculatePrice();
        bool purchaseSuccess = gameManager.PurchaseAction(price);
        if (purchaseSuccess)
        {
            level++;
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        priceText.text = CalculatePrice().ToString();
        incomeInfoText.text = level.ToString() + " x " + FaithPerUpgrade + "/S";
    }
    int CalculatePrice()
    {
        int price = Mathf.RoundToInt(startPrice * Mathf.Pow(upgradePriceMultiplier, level));
        return price;
    }

    public float CalculateFaithPerSecond()
    {
        return FaithPerUpgrade * level;
    }
}
