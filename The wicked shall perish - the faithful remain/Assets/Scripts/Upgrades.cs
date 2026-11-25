using TMPro;
using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Upgrades : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI faithPriceText;
    public TextMeshProUGUI populationPriceText;
    public TextMeshProUGUI foodPriceText;
    public TextMeshProUGUI housingPriceText;
    public TextMeshProUGUI militiaPriceText;
    public TextMeshProUGUI incomeInfoText;

    [Header("Generator values")]
    private int startPrice = 100;
    private int populationStartPrice = 100;
    private int foodStartPrice = 100;
    private int militiaStartPrice = 100;
    private int housingStartPrice = 100;
    public float upgradePriceMultiplier;
   
    //public float FaithPerUpgrade = 0.1f;

    [Header("Managers")]
    public GameManager gameManager;
    public GlobalResources globalResources;
    public int level = 0;
    public int faithLevel = 0;
    public int populationLevel = 0;
    public int foodLevel = 0;
    public int housingLevel = 0;
    public int militiaLevel = 0;

    private void Start()
    {
        UpdateUI(0);
        UpdateUI(1);
        UpdateUI(2);
        UpdateUI(3);
        UpdateUI(4);
    }

    void Update()
    {
        //UpdateUI();

    }
    public void ClickFaithUpgrade()
    {
        int faithPrice = CalculateFaithPrice();

        bool purchaseSuccess = gameManager.PurchaseAction(faithPrice);
        if (purchaseSuccess)
        {
            faithLevel++;
            UpdateUI(0);
        }
    }

    public void ClickPopulationUpgrade()
    {
        int populationPrice = CalculatePopulationPrice();

        bool purchaseSuccess = gameManager.PurchaseAction(populationPrice);
        if (purchaseSuccess)
        {
            populationLevel++;
            UpdateUI(1);
           
        }
    }
    public void ClickMilitiaUpgrade()
    {
        int militiaPrice = CalculateMilitiaPrice();

        bool purchaseSuccess = gameManager.PurchaseActionMoney(militiaPrice);
        if (purchaseSuccess)
        {
            globalResources.MilitiaBuy();
            militiaLevel++;
            UpdateUI(2);
           
        }
    }
    public void ClickFoodUpgrade()
    {
        int foodPrice = CalculateFoodPrice();

        bool purchaseSuccess = gameManager.PurchaseActionMoney(foodPrice);
        if (purchaseSuccess)
        {
            foodLevel++;
            globalResources.FoodBuy();
            UpdateUI(3);
           
        }
    }
    
    public void ClickHousingUpgrade()
    {
        int housingPrice = CalculateHousingPrice();

        bool purchaseSuccess = gameManager.PurchaseActionMoney(housingPrice);
        if (purchaseSuccess)
        {
            housingLevel++;
            globalResources.HouseBuy();
            UpdateUI(4);
           
        }
    }
    
    // Calculations for each upgrade prices
    int CalculateFaithPrice()
    {
        int faithPrice = Mathf.RoundToInt(Mathf.Pow(startPrice, faithLevel + 1) * upgradePriceMultiplier); 
        return faithPrice;
        
    }
    int CalculatePopulationPrice()
    {
        int populationPrice = Mathf.RoundToInt(Mathf.Pow(populationStartPrice, populationLevel + 1) * upgradePriceMultiplier);
        return populationPrice;
    }
    //Upgrades use money
    int CalculateMilitiaPrice()
    {
        int militiaPrice = Mathf.RoundToInt(Mathf.Pow(militiaStartPrice, militiaLevel + 1) * upgradePriceMultiplier);
        return militiaPrice;
    }
    int CalculateFoodPrice()
    {
        int foodPrice = Mathf.RoundToInt(Mathf.Pow(foodStartPrice, foodLevel + 1) * upgradePriceMultiplier);
        return foodPrice;
    }
    int CalculateHousingPrice()
    {
        int housingPrice = Mathf.RoundToInt(Mathf.Pow(housingStartPrice, housingLevel + 1) * upgradePriceMultiplier);
        return housingPrice;
    }

    /*public float CalculateFaithPerSecond()
    {
        return FaithPerUpgrade * level;
        
    }*/

    void UpdateUI(int upgradeID)
    {
        switch (upgradeID)
        {
            case 0:
                faithPriceText.text = "Cost: " + CalculateFaithPrice().ToString();
                incomeInfoText.text = "Level: " + faithLevel.ToString();
                
                break;

            case 1:
                populationPriceText.text = "Cost: " + CalculatePopulationPrice().ToString();
                incomeInfoText.text = "Level: " + populationLevel.ToString();
                break;

            case 2:
                militiaPriceText.text = "Cost: " + CalculateMilitiaPrice().ToString();
                incomeInfoText.text = "Level: " + militiaLevel.ToString();
                break;
            case 3:
                foodPriceText.text = "Cost: " + CalculateFoodPrice().ToString();
                incomeInfoText.text = "Level: " + foodLevel.ToString();
                break;
            case 4:
                housingPriceText.text = "Cost: " + CalculateHousingPrice().ToString();
                incomeInfoText.text = "Level: " + housingLevel.ToString();
                break;
        }
    }
    /*private void UpdateUI()
    {
        /* populationPriceText.text = CalculatePopulationPrice().ToString();
         Debug.Log(populationPriceText.text);
         faithPriceText.text = CalculateFaithPrice().ToString();
         //incomeInfoText.text = level.ToString() + " x " + FaithPerUpgrade + "/S";
       
        
         int faithPrice = CalculateFaithPrice();
         int populationPrice = CalculatePopulationPrice();

         Debug.Log($"Faith: {faithPrice}");
         Debug.Log($"Population: {populationPrice}");

         faithPriceText.text = faithPrice.ToString();
         populationPriceText.text = populationPrice.ToString();
      
    }*/
}
