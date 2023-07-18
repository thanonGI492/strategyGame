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
                    + "Coppers: " + cost.CostCopper.ToString() + "\n" + "Enegy: -5";
                break;

            case "Goldmine":
                hoverText.text = "Coppers: " + cost.CostCopper.ToString() + "\n"
                    + "Iron: " + cost.CostIron.ToString() + "\n" + "Enegy: -10";
                break;

            case "Solar":
                hoverText.text ="Stones: " + cost.CostStone.ToString() + "\n"
                    + "Coppers: " + cost.CostCopper.ToString() + "\n"
                    + "Iron: " + cost.CostIron.ToString() + "\n" + "Enegy: +4";
                break;

            case "Hydroelectricplant":
                hoverText.text = "Stones: " + cost.CostStone.ToString() + "\n"
                    + "Coppers: " + cost.CostCopper.ToString() + "\n"
                    + "Iron: " + cost.CostIron.ToString() + "\n" + "Enegy: +5";
                break;

            case "Windmill":
                 hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString()+ "\n" + "Enegy: +2";
                break;

            case "Thermalplant":
                 hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString()+ "\n" + "Enegy: +3";
                break;

            case (_):
                hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString()+ "\n" + "Enegy: -2";
                break;
            
        }
    }
}
