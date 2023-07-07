using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsResource : MonoBehaviour
{
    public static StatsResource Instance;

    [SerializeField] private Text energyText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text stoneText;
    [SerializeField] private int beginResource;

    //public variable
    [HideInInspector] public static int TotalEnergy;
    [HideInInspector] public static int TotalWood;
    [HideInInspector] public static int TotalStone;
    public CostBuilding CostSawMill;
    public CostBuilding CostStoneMine;

    #region Unity Method
    private void Awake()
    {
        Instance = this;

        
    }

    private void Start()
    {
        TotalWood = beginResource;
        TotalStone = beginResource;
    }

    private void Update()
    {
        energyText.text = "Energy: " + TotalEnergy.ToString();
        woodText.text = "Wood: " + TotalWood.ToString();
        stoneText.text = "Stone: " + TotalStone.ToString();
    }

    #endregion


    #region Custom Method

    public void SpawnGen(int cost)
    {
        if (TotalEnergy < cost)
        {
            Debug.Log("Insufficient Resource");
            return;
        }
        TotalEnergy -= cost;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    public void SpawnWindMill(int cost)
    {
        if (TotalWood < cost || TotalStone < cost)
        {
            Debug.Log("Insufficient Resource");
            return;
        }
        TotalWood -= cost;
        TotalStone -= cost;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    public void SpawnSawMill() 
    { 
        if (TotalWood < CostSawMill.CostWood || TotalStone < CostSawMill.CostStone || TotalEnergy < CostSawMill.CostEnergy)
        {
            Debug.Log("Insufficient Resource");
            GridBuildingSystem.Instance.IsSpawningObj = true;
            return;
        }
        TotalEnergy -= CostSawMill.CostEnergy;
        TotalWood -= CostSawMill.CostWood;
        TotalStone -= CostSawMill.CostStone;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    public void SpawnStoneMine()
    {
        if (TotalWood < CostStoneMine.CostWood || TotalStone < CostStoneMine.CostStone || TotalEnergy < CostStoneMine.CostEnergy)
        {
            Debug.Log("Insufficient Resource");
            GridBuildingSystem.Instance.IsSpawningObj = true;
            return;
        }
        TotalEnergy -= CostStoneMine.CostEnergy;
        TotalWood -= CostStoneMine.CostWood;
        TotalStone -= CostStoneMine.CostStone;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    #endregion
}
