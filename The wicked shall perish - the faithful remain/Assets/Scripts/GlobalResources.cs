using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GlobalResources : MonoBehaviour
{
    public static int faithCount;
    public static int populationCount;
    public static int moneyCount;

    public int InternalFaith;
    public int InternalMoney;
    public int InternalPopulation;

    public TextMeshProUGUI moneyLabel;
    public TextMeshProUGUI populationLabel;
    public TextMeshProUGUI faithLabel;

    private void Update()
    {
        InternalFaith = faithCount;
        InternalMoney = moneyCount;
        InternalPopulation = populationCount;
        faithLabel.text = "Faith: " + faithCount;
        moneyLabel.text = "Money: " + moneyCount;
        populationLabel.text = "Population: " + populationCount;
    }
}
