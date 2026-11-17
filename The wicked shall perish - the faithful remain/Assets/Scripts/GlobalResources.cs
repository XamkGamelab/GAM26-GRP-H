using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GlobalResources : MonoBehaviour
{
    //Hidden static int
    public static int faithCount;
    public static int populationCount;
    public static int moneyCount;
    public static int foodCount;
    public static int housingCount;
    public static int militiaCount;
    public static int hereticCount;

    //Visible int
    public int InternalFaith;
    public int InternalMoney;
    public int InternalPopulation;
    public int InternalFood;
    public int InternalHousing;
    public int InternalMilitia;
    public int InternalHeretics;


    //Text UI elements
    public TextMeshProUGUI faithLabel;
    public TextMeshProUGUI populationLabel;
    public TextMeshProUGUI moneyLabel;
    public TextMeshProUGUI foodLabel;
    public TextMeshProUGUI housingLabel;
    public TextMeshProUGUI militiaLabel;
    public TextMeshProUGUI hereticLabel;

    float nextTimeCheck = 1;

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
            nextTimeCheck = Time.timeSinceLevelLoad + 1f;

        }
        
    }

    public void UpdateUI()
    {
        faithLabel.text = "Faith: " + faithCount;
        moneyLabel.text = "Money: " + moneyCount;
        populationLabel.text = "Population: " + populationCount;
        foodLabel.text = "Food: " + foodCount;
        housingLabel.text = "Housing: " + housingCount;
        militiaLabel.text = "Militia: " + militiaCount;
        hereticLabel.text = "Heretics: " + hereticCount;

    }
    public void FaithGen()
    {
       if (populationCount >= 1)
       {
            faithCount++;
            

       }

       
    }

    public void PopulationGen()
    {
        populationCount++;
         
    }

    public void MoneyGen()
    {
        //moneyCount++;
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

    }

}
