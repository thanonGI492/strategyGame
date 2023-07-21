using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool : MonoBehaviour
{
    [SerializeField] private int AddResource;

    public void newresource()
    {
        //StatsResource.TotalEnergy += AddResource;
        StatsResource.TotalWood += AddResource;
        StatsResource.TotalCopper += AddResource;
        StatsResource.TotalGold += AddResource;
        StatsResource.TotalIron += AddResource;
        StatsResource.TotalStone += AddResource;
    }
}
