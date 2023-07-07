using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cost/Building")]
public class CostBuilding : ScriptableObject
{
    public string nameBuilding;
    public int costWood;
    public int costStone;
    public int costCopper;
    public int costIron;
    public int costGold;
    public int costEnergy;
}
