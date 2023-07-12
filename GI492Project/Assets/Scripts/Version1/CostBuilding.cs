using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cost/Building")]
public class CostBuilding : ScriptableObject
{
    public string NameBuilding;
    public int CostWood;
    public int CostStone;
    public int CostCopper;
    public int CostIron;
    public int CostGold;
    public int ReturnENG;
}
