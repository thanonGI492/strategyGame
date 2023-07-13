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
    [SerializeField] private Text copperText;
    [SerializeField] private Text ironText;
    [SerializeField] private Text goldText;
    [SerializeField] private int beginResource;

    //public variable
    [HideInInspector] public static int TotalEnergy;
    [HideInInspector] public static int TotalWood;
    [HideInInspector] public static int TotalStone;
    [HideInInspector] public static int TotalCopper;
    [HideInInspector] public static int TotalIron;
    [HideInInspector] public static int TotalGold;
    [HideInInspector] public bool WaitingPlace;


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
        copperText.text = "Copper: " + TotalCopper.ToString();
        ironText.text = "Iron: " + TotalIron.ToString();
        goldText.text = "Gold: " + TotalGold.ToString();
    }

    #endregion


    #region Custom Method

    public void SpawnGen(CostBuilding cost)
    {
        if (WaitingPlace)
        {
            return;
        }

        if (TotalWood < cost.CostWood || TotalStone < cost.CostStone || TotalCopper < cost.CostCopper || TotalIron < cost.CostIron)
        {
            Debug.Log("Insufficient Resource");
            GridBuildingSystem.Instance.IsSpawningObj = true;
            return;
        }
        TotalWood -= cost.CostWood;
        TotalStone -= cost.CostStone;
        TotalCopper -= cost.CostCopper;
        TotalIron -= cost.CostIron;
        TotalGold -= cost.CostGold;
        WaitingPlace = true;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    #endregion
}
