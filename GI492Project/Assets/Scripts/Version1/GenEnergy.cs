using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenEnergy : MonoBehaviour
{
    [SerializeField] private int energyPower;

    //private variable
    private bool _placed;

    #region Unity Method

    private void OnMouseUp()
    {
        if (_placed)
        {
            return;
        }

        StatsResource.TotalEnergy += energyPower;
        _placed = true;
    }

    #endregion
}
