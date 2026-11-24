using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GlobalResources : MonoBehaviour
{
    //Hidden static float
    public static float faithCount = 0;
    public static float populationCount = 0;
    public static float moneyCount = 0;
    public static float foodCount = 0;
    public static float housingCount = 0;
    public static float militiaCount = 0;
    public static float hereticCount = 0;

    //Visible float
    [Header("Resources")]
    public float InternalFaith;
    public float InternalMoney;
    public float InternalPopulation;
    public float InternalFood;
    public float InternalHousing;
    public float InternalMilitia;
    public float InternalHeretics;


    //Text UI elements
    [Header("UI Elements")]
    public TextMeshProUGUI faithLabel;
    public TextMeshProUGUI populationLabel;
    public TextMeshProUGUI moneyLabel;
    public TextMeshProUGUI foodLabel;
    public TextMeshProUGUI housingLabel;
    public TextMeshProUGUI militiaLabel;
    public TextMeshProUGUI hereticLabel;

    //time check
    [Header("TimeCheck")]
    float nextTimeCheck = 1;

    //constant values for formulas
    [Header("Constants")]
    float FaithPerCitizen = 2;
    float MoneyPerCitizen = 2;
    float populationConstant = 2;
    float foodConstant = 1;
    float housingConstant = 1;
    float militiaConstant = 1;
    float HereticMultiplier = 0.1f;

    //upgrade values and other modifiers
    [Header("Modifiers and upgrades")]
    public int faithUpgradeLevel = 0;
    public int moneyUpgradeLevel = 0;
    public int populationUpgradeLevel = 0;
    public int foodUpgradeLevel = 0;
    public int housingUpgradeLevel = 0;
    public int militiaUpgradeLevel = 0;

    public float GrowthLimiter = 0.5f;

    //buy variables
    [Header("Buy event values")]
    public float missionaryTrip = 1;
    public float buyFood;
    public float buyHousing;
    public float buyMilitia;

    //click variables

    public GameObject faithUpgrades;
    public GameObject populationUpgrades;

    
    private void Start()
    {
        faithCount = 0;
        populationCount = 0;
        moneyCount = 0;
        foodCount = 0;
        housingCount = 0;
        militiaCount = 0;
        hereticCount = 0;
        

        faithUpgradeLevel = faithUpgrades.GetComponent<Upgrades>().faithLevel;
        populationUpgradeLevel = populationUpgrades.GetComponent<Upgrades>().populationLevel;

    }
    private void Update()
    {
        InternalFaith = faithCount;
        InternalMoney = moneyCount;
        InternalPopulation = populationCount;
        InternalFood = foodCount;
        InternalHousing = housingCount;
        InternalMilitia = militiaCount;
        InternalHeretics = hereticCount;

        populationUpgradeLevel = populationUpgrades.GetComponent<Upgrades>().populationLevel;
        faithUpgradeLevel = faithUpgrades.GetComponent<Upgrades>().faithLevel;

        UpdateUI();
        
        

        if (nextTimeCheck < Time.timeSinceLevelLoad)
        {
            if(populationUpgradeLevel >= 1)
            {
                PopulationGen();
            }
            if(foodUpgradeLevel >= 1)
            {
                FoodGen();
            }
            if(housingUpgradeLevel >= 1)
            {
                HousingGen();
            }
            if(militiaUpgradeLevel >= 1)
            {
                MilitiaGen();
            }
            else
            {
                FaithGen();
                MoneyGen();
                HereticGen();
            }
            
           
            nextTimeCheck = Time.timeSinceLevelLoad + 1f;

        }


    }

    

    public void UpdateUI()
    {
        faithLabel.text = "Faith: " + Mathf.RoundToInt(faithCount).ToString();//"Faith: " + faithCount;
        moneyLabel.text = "Money: " + Mathf.RoundToInt(moneyCount).ToString();//moneyCount;
        populationLabel.text = "Population: " + Mathf.RoundToInt(populationCount).ToString(); //populationCount;
        foodLabel.text = "Food: " + Mathf.RoundToInt(foodCount).ToString(); //foodCount;
        housingLabel.text = "Housing: " + Mathf.RoundToInt(housingCount).ToString(); //housingCount;
        militiaLabel.text = "Militia: " + Mathf.RoundToInt(militiaCount).ToString();// militiaCount;
        hereticLabel.text = "Heretics: " + Mathf.RoundToInt(hereticCount).ToString(); //hereticCount;

    }

    public void PopulationGen()
    {
        populationCount += (Mathf.Pow(populationConstant, 1 + populationUpgradeLevel)) * GrowthLimiter;
    }
    public void PopulationClick()
    {
        populationCount+= missionaryTrip;
    }

    public void FaithGen()
    {
        //faithUpgradeLevel = upgrades.GetComponent<Upgrades>().faithLevel;
        faithCount += (Mathf.Pow(FaithPerCitizen, 1 + faithUpgradeLevel) * populationCount) * GrowthLimiter;
        faithCount -= hereticCount;
    }

    public void MoneyGen()
    {
        moneyCount += (Mathf.Pow(MoneyPerCitizen, 1 + moneyUpgradeLevel) * populationCount) * GrowthLimiter;
    }

    public void FoodGen()
    {
        foodCount += Mathf.Pow(foodConstant, 1 + foodUpgradeLevel) * GrowthLimiter;
        //foodCount++;
    }

    public void FoodBuy()
    {
        foodCount += buyFood;
    }

    public void HousingGen()
    {
        housingCount += (Mathf.Pow(housingConstant, 1 + housingUpgradeLevel)) * GrowthLimiter;
    }

    public void MilitiaGen()
    {
        militiaCount += (Mathf.Pow(militiaConstant, 1 + militiaUpgradeLevel)) * GrowthLimiter;
    }

    public void HereticGen()
    {
        hereticCount = populationCount * HereticMultiplier;
        hereticCount -= militiaCount;
    }

}
