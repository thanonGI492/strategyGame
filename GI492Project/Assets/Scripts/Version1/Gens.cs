using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gens : MonoBehaviour
{

    [SerializeField] private float controlStatGens;
    [SerializeField] private int spawnTime;
    [SerializeField] private int energyDrain;
    [SerializeField] private int drainTime;
    [SerializeField] private int BlackOut = 1;
    [SerializeField] private int CapBlackOut = -10;
    [SerializeField] private int Gendown = 0;
    

    //private variable
    private int _baseLv = 1;
    private bool _placed;
    //public variable
    public CostBuilding Building;

    #region Unity Method
    private void OnMouseUp()
    {
        
        if (_placed)
        {
            return;
        }

        if (BuildingSystem.Instance.Placed)
        {
            switch (Building.NameBuilding)
            {
                case "Windmill":
                    StartCoroutine(energyGen());
                    break;
                case "Sawmill":
                    StartCoroutine(woodGen());
                    break;
                case "Stonemine":
                    StartCoroutine(stoneGen());
                    break;
                case "Coppermine":
                    StartCoroutine(copperGen());
                    break;
                case "Ironmine":
                    StartCoroutine(ironGen());
                    break;
                case "Goldmine":
                    StartCoroutine(goldGen());
                    break;
            }
            if (StatsResource.TotalEnergy > CapBlackOut)
            {
                StatsResource.TotalEnergy -= energyDrain;
                _placed = true;
                GridBuildingSystem.Instance.IsSpawningObj = true;
            }
            else
            {
                StatsResource.TotalEnergy = CapBlackOut;
            }
        }
    }

    /*IEnumerator EnergyDrain()
    {
        yield return new WaitForSeconds(drainTime);
        if (StatsResource.TotalEnergy >= CapBlackOut)
        {
            StatsResource.TotalEnergy -= energyDrain;
        }
        else
        {
            StatsResource.TotalEnergy = CapBlackOut;
        }
        
        StartCoroutine(EnergyDrain());
    }
    */
    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalEnergy += (int)(_baseLv * controlStatGens);
    }

    IEnumerator woodGen()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
             StatsResource.TotalWood += (int)(_baseLv * controlStatGens);
        }
        StartCoroutine(woodGen());
        
    }

    IEnumerator stoneGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            StatsResource.TotalStone += (int)(_baseLv * controlStatGens);
        }
        StartCoroutine(stoneGen());
    }

    IEnumerator copperGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            StatsResource.TotalCopper += (int)(_baseLv * controlStatGens);
        }
        StartCoroutine(copperGen());
    }

    IEnumerator ironGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            StatsResource.TotalIron += (int)(_baseLv * controlStatGens);
        }
       
        StartCoroutine(ironGen());
    }

    IEnumerator goldGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            StatsResource.TotalGold += (int)(_baseLv * controlStatGens);
        }
        StartCoroutine(goldGen());
    }
    #endregion
}
