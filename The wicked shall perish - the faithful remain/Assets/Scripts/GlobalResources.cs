using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GlobalResources : MonoBehaviour
{
    //Hidden static int
    public static float faithCount;
    public static float populationCount;
    public static float moneyCount;
    public static float foodCount;
    public static float housingCount;
    public static float militiaCount;
    public static float hereticCount;

    //Visible int
    public float InternalFaith;
    public float InternalMoney;
    public float InternalPopulation;
    public float InternalFood;
    public float InternalHousing;
    public float InternalMilitia;
    public float InternalHeretics;


    //Text UI elements
    public TextMeshProUGUI faithLabel;
    public TextMeshProUGUI populationLabel;
    public TextMeshProUGUI moneyLabel;
    public TextMeshProUGUI foodLabel;
    public TextMeshProUGUI housingLabel;
    public TextMeshProUGUI militiaLabel;
    public TextMeshProUGUI hereticLabel;

    float nextTimeCheck = 1;
    float HereticMultiplier = 0.1f;
    float FaithPerCitizen = 2;

    private void Update()
    {
        InternalFaith = faithCount;
        InternalMoney = moneyCount;
        InternalPopulation = populationCount;
        InternalFood = foodCount;
        InternalHousing = housingCount;
        InternalMilitia = militiaCount;
        InternalHeretics = hereticCount;

        UpdateUI();

        if(nextTimeCheck < Time.timeSinceLevelLoad)
        {
            FaithGen();
            PopulationGen();
            MoneyGen();
            FoodGen();
            HousingGen();
            MilitiaGen();
            HereticGen();
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
    public void FaithGen()
    {
       faithCount = populationCount * FaithPerCitizen;
        faithCount -= hereticCount;
    }

    public void PopulationGen()
    {
        populationCount++;
        
    }

    public void MoneyGen()
    {
        moneyCount = populationCount * 2;
    }

    public void FoodGen()
    {
        //foodCount++;
    }

    public void HousingGen()
    {

    }

    public void MilitiaGen()
    {

    }

    public void HereticGen()
    {
        hereticCount = populationCount * HereticMultiplier;
    }

}
