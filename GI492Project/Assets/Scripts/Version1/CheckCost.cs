using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCost : MonoBehaviour
{
    public CostBuilding Building;

    public void OnMouseUp()
    {
        if (BuildingSystem.Instance.Placed)
        {
            StatsResource.TotalWood -= Building.CostWood;
            StatsResource.TotalStone -= Building.CostStone;
            StatsResource.TotalCopper -= Building.CostCopper;
            StatsResource.TotalIron -= Building.CostIron;
            StatsResource.TotalGold -= Building.CostGold;
            GridBuildingSystem.Instance.IsSpawningObj = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
