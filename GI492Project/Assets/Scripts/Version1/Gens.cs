using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gens : MonoBehaviour
{

    [SerializeField] private float controlStatGens;
    [SerializeField] private string nameGen;

    //private variable
    private int _baseLv = 1;

    #region Unity Method
    private void OnMouseUp()
    {
        if (gameObject.name.Contains(nameGen))
        {
            StartCoroutine(energyGen());
        }
        GridBuildingSystem.Instance.IsSpawningObj = true;
    }

    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(5);
        StatsResource.TotalEnergy += (int)(_baseLv * controlStatGens);
        StartCoroutine(energyGen());
    }
    #endregion
}
