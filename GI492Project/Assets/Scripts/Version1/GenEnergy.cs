using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenEnergy : MonoBehaviour
{
    [SerializeField] private int energyPower;

    #region Unity Method

    private void OnMouseUp()
    {
        StatsResource.TotalEnergy += energyPower;
    }

    #endregion
}
