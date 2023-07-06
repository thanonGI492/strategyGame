using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsResource : MonoBehaviour
{
    public static StatsResource Instance;

    [SerializeField] private Text energyText;

    //public variable
    [HideInInspector] public static int TotalEnergy;
    [HideInInspector] public static int TotalWood;
    
    #region Unity Method
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TotalEnergy = 5;
        TotalWood = 0;
    }

    private void Update()
    {
        energyText.text = "Energy: " + TotalEnergy.ToString();
    }

    #endregion


    #region Custom Method

    public void SpawnEnergyGen(int cost)
    {
        if (TotalEnergy < cost)
        {
            Debug.Log("Insufficient Resource");
            return;
        }
        TotalEnergy -= cost;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    #endregion
}
