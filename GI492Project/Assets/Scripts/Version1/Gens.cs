using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gens : MonoBehaviour
{

    [SerializeField] private float controlStatGens;
    [SerializeField] private int spawnTime;
    [SerializeField] private int energyDrain;

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
        }

        _placed = true;
        GridBuildingSystem.Instance.IsSpawningObj = true;
    }

    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalEnergy += (int)(_baseLv * controlStatGens);
        StartCoroutine(energyGen());
    }

    IEnumerator woodGen()
    {
        StatsResource.TotalEnergy -= energyDrain;
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalWood += (int)(_baseLv * controlStatGens);
        StartCoroutine(woodGen());
    }

    IEnumerator stoneGen()
    {
        StatsResource.TotalEnergy -= energyDrain;
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalStone += (int)(_baseLv * controlStatGens);
        StartCoroutine(stoneGen());
    }
    #endregion
}
