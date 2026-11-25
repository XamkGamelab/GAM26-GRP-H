using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GlobalResources GlobalResources;
    public TextMeshProUGUI incomeText;
    [SerializeField] Upgrades[] upgrades;

    float lastFaithValue = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        IdleCalculate();
    }

    void UpdateUI()
    {

    }
    

    void IdleCalculate()
    {
        float sum = 0;
        foreach (var Upgrades in upgrades)
        {
            sum += Upgrades.CalculateFaithPerSecond();
        }
        incomeText.text = lastFaithValue.ToString() + "/S";
        lastFaithValue = sum;
    }

    public bool PurchaseAction(int cost)
    {
        if (GlobalResources.faithCount >= cost)
        {
            GlobalResources.faithCount -= cost;
            return true;
        }
        return false;
    }
}
