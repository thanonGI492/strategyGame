using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gens : MonoBehaviour
{

    [SerializeField] private float controlStatGens;
    [SerializeField] private int spawnTime;
    [SerializeField] private int energyDrain;
    [SerializeField] private int drainTime;

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

        if (Building.NameBuilding != "Windmill")
        {
            StartCoroutine(EnergyDrain());
        }


        _placed = true;
        GridBuildingSystem.Instance.IsSpawningObj = true;
    }

    IEnumerator EnergyDrain()
    {
        yield return new WaitForSeconds(drainTime);
        StatsResource.TotalEnergy -= energyDrain;
        StartCoroutine(EnergyDrain());
    }

    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalEnergy += (int)(_baseLv * controlStatGens);
        StartCoroutine(energyGen());
    }

    IEnumerator woodGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalWood += (int)(_baseLv * controlStatGens);
        StartCoroutine(woodGen());
    }

    IEnumerator stoneGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalStone += (int)(_baseLv * controlStatGens);
        StartCoroutine(stoneGen());
    }

    IEnumerator copperGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalCopper += (int)(_baseLv * controlStatGens);
        StartCoroutine(copperGen());
    }

    IEnumerator ironGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalIron += (int)(_baseLv * controlStatGens);
        StartCoroutine(ironGen());
    }

    IEnumerator goldGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalGold += (int)(_baseLv * controlStatGens);
        StartCoroutine(goldGen());
    }
    #endregion
}
