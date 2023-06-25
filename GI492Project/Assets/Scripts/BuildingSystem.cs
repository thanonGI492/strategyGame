using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public bool Placed {get; private set;}

    [Header("Setting")]
    public BoundsInt area;

    private void Start(){

    }

    #region Build Method

    public bool CanBePlaced(){
        Vector3Int positionInt = GridBuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.Instance.CanTakeArea(areaTemp)){
            return true;
        }

        return false;
    }

    public void Place(){
        Vector3Int positionInt = GridBuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.Instance.TakeArea(areaTemp);
    }

    #endregion

}
