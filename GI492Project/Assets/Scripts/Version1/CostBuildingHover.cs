using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostBuildingHover : MonoBehaviour
{
    [SerializeField] private Text hoverText;
    [SerializeField] private CostBuilding cost;

    private void OnEnable()
    {
        switch (cost.NameBuilding)
        {
            case "Ironmine":
                hoverText.text = " " + cost.CostStone.ToString() + "\n"
                    + " " + cost.CostCopper.ToString() + "\n" + " -" + cost.ReturnENG;
                break;

            case "Goldmine":
                hoverText.text = " " + cost.CostCopper.ToString() + "\n"
                    + " " + cost.CostIron.ToString() + "\n" + " -" + cost.ReturnENG;
                break;

            case "Hydroelectricplant":
            case "Solar":
                hoverText.text =" " + cost.CostStone.ToString() + "\n"
                    + " " + cost.CostCopper.ToString() + "\n"
                    + " " + cost.CostIron.ToString() + "\n" + " +" + cost.DeductENG;
                break;

            case "Windmill":
                 hoverText.text = " " + cost.CostWood.ToString() + "\n" 
                    + " " + cost.CostStone.ToString()+ "\n" + " +" + cost.DeductENG;
                break;

            case "Thermalplant":
                 hoverText.text = "      " + cost.CostWood.ToString() + "\n" 
                    + "      " + cost.CostStone.ToString()+ "\n" + "      +" + cost.DeductENG + "\n" 
                    + "Cost: " + cost.DrainResource + "/" + cost.DrainTime + "S";
                break;

            case (_):
                hoverText.text = " " + cost.CostWood.ToString() + "\n" 
                    + " " + cost.CostStone.ToString()+ "\n" + " -" + cost.ReturnENG;
                break;
            
        }
    }
}
