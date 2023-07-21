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
                hoverText.text = "Stones: " + cost.CostStone.ToString() + "\n"
                    + "Coppers: " + cost.CostCopper.ToString() + "\n" + "Enegy: -" + cost.ReturnENG;
                break;

            case "Goldmine":
                hoverText.text = "Coppers: " + cost.CostCopper.ToString() + "\n"
                    + "Iron: " + cost.CostIron.ToString() + "\n" + "Enegy: -" + cost.ReturnENG;
                break;

            case "Hydroelectricplant":
            case "Solar":
                hoverText.text ="Stones: " + cost.CostStone.ToString() + "\n"
                    + "Coppers: " + cost.CostCopper.ToString() + "\n"
                    + "Iron: " + cost.CostIron.ToString() + "\n" + "Enegy: +" + cost.DeductENG;
                break;

            case "Windmill":
                 hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString()+ "\n" + "Enegy: +" + cost.DeductENG;
                break;

            case "Thermalplant":
                 hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString()+ "\n" + "Enegy: +" + cost.DeductENG + "\n" 
                    + "Cost: Wood " + cost.DrainResource + "/" + cost.DrainTime + "S";
                break;

            case (_):
                hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString()+ "\n" + "Enegy: -" + cost.ReturnENG;
                break;
            
        }
    }
}
