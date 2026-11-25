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
    public TextMeshProUGUI militiaPriceText;
    public TextMeshProUGUI incomeInfoText;

    [Header("Generator values")]
    public int startPrice = 100;
    public int populationStartPrice = 100;
    public int militiaStartPrice = 100;
    public float upgradePriceMultiplier;
    //public float FaithPerUpgrade = 0.1f;

    [Header("Managers")]
    public GameManager gameManager;
    public int level = 0;
    public int faithLevel = 0;
    public int populationLevel = 0;
    public int militiaLevel = 0;

    private void Start()
    {
        UpdateUI(0);
        UpdateUI(1);
        UpdateUI(2);
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
            militiaLevel++;
            UpdateUI(2);
           
        }
    }
    
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
    int CalculateMilitiaPrice()
    {
        int militiaPrice = Mathf.RoundToInt(Mathf.Pow(militiaStartPrice, militiaLevel + 1) * upgradePriceMultiplier);
        return militiaPrice;
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
                faithPriceText.text = CalculateFaithPrice().ToString();
                incomeInfoText.text = "Level: " + faithLevel.ToString() + " x " + "/S";
                
                break;

            case 1:
                populationPriceText.text = CalculatePopulationPrice().ToString();
                incomeInfoText.text = "Level: " + populationLevel.ToString() + " x " + "/S";
                break;

            case 2:
                militiaPriceText.text = CalculateMilitiaPrice().ToString();
                incomeInfoText.text = "Level: " + militiaLevel.ToString() + " x " + "/S";
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
