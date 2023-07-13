using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCost : MonoBehaviour
{
    public static CheckCost Instance;

    public CostBuilding Building;
    public bool _ifPlaced;
    [HideInInspector] public bool Placed;

    private void Awake()
    {
        Instance = this;
    }

    public void OnMouseUp()
    {
        if (_ifPlaced)
        {
            return;
        }

        if (BuildingSystem.Instance.Placed && Placed)
        {
            StatsResource.TotalWood -= Building.CostWood;
            StatsResource.TotalStone -= Building.CostStone;
            StatsResource.TotalCopper -= Building.CostCopper;
            StatsResource.TotalIron -= Building.CostIron;
            StatsResource.TotalGold -= Building.CostGold;
            GridBuildingSystem.Instance.IsSpawningObj = false;
            _ifPlaced = true;
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
