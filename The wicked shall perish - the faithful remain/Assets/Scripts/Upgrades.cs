using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assemblies;

public class Upgrades : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI faithPriceText;
    public TextMeshProUGUI populationPriceText;
    public TextMeshProUGUI incomeInfoText;

    [Header("Generator values")]
    public int startPrice = 100;
    public float upgradePriceMultiplier;
    public float FaithPerUpgrade = 0.1f;

    [Header("Managers")]
    public GameManager gameManager;
    public int level = 0;
    public int faithLevel = 0;
    public int populationLevel = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void ClickFaithUpgrade()
    {
        int faithPrice = CalculateFaithPrice();

        bool purchaseSuccess = gameManager.PurchaseAction(faithPrice);
        if (purchaseSuccess)
        {
            faithLevel++;
            UpdateUI();
        }
    }

    public void ClickPopulationUpgrade()
    {
        int populationPrice = CalculatePopulationPrice();

        bool purchaseSuccess = gameManager.PurchaseAction(populationPrice);
        if (purchaseSuccess)
        {
            populationLevel++;
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        populationPriceText.text = CalculatePopulationPrice().ToString();
        faithPriceText.text = CalculateFaithPrice().ToString();
        incomeInfoText.text = level.ToString() + " x " + FaithPerUpgrade + "/S";
    }
    int CalculateFaithPrice()
    {
        int price = Mathf.RoundToInt(Mathf.Pow(startPrice, faithLevel + 1) * upgradePriceMultiplier);
        return price;
    }
    int CalculatePopulationPrice()
    {
        int price = Mathf.RoundToInt(Mathf.Pow(startPrice, populationLevel + 1) * upgradePriceMultiplier);
        return price;
    }

    public float CalculateFaithPerSecond()
    {
        return FaithPerUpgrade * level;
        
    }
}
