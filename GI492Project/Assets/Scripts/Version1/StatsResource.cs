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
    public CostBuilding _costBuilding;

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
        if (TotalWood < _costBuilding.costWood || TotalStone < _costBuilding.costStone || TotalEnergy < _costBuilding.costEnergy)
        {
            Debug.Log("Insufficient Resource");
            return;
        }
        TotalEnergy -= _costBuilding.costEnergy;
        TotalWood -= _costBuilding.costWood;
        TotalStone -= _costBuilding.costStone;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    #endregion
}
