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
                    + "Coppers: " + cost.CostCopper.ToString();
                break;
            case "Goldmine":
                hoverText.text = "Coppers: " + cost.CostCopper.ToString() + "\n"
                    + "Iron: " + cost.CostIron.ToString();
                break;
            case (_):
                hoverText.text = "Woods: " + cost.CostWood.ToString() + "\n" 
                    + "Stones: " + cost.CostStone.ToString();
                break;
            
        }
    }
}
