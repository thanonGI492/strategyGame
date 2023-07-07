using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gens : MonoBehaviour
{

    [SerializeField] private float controlStatGens;
    [SerializeField] private int spawnTime;

    //private variable
    private int _baseLv = 1;
    //public variable
    public CostBuilding costSawMill;

    #region Unity Method
    private void OnMouseUp()
    {
        if (gameObject.name.Contains(costSawMill.NameBuilding))
        {
            StartCoroutine(woodGen());
        }
        else if (gameObject.name.Contains("StoneMine"))
        {
            StartCoroutine(stoneGen());
        }

        GridBuildingSystem.Instance.IsSpawningObj = true;
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
    #endregion
}
