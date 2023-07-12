using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;
    

    public bool Placed {get; private set;}

    [Header("Setting")]
    public BoundsInt area;

    //private Variable
    private Vector3 _offSet;
    private Vector3 _prevPos;

    #region Unity Method

    private void Awake()
    {
        Instance = this;
    }

    private void OnMouseDown(){
        _offSet = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag(){

        if (Placed) return;

        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offSet;
        Vector3Int cellPos = GridBuildingSystem.Instance.GridLayout.LocalToCell(touchPos);
        
        if (_prevPos != cellPos){
                GridBuildingSystem.Instance.Temp.transform.localPosition = GridBuildingSystem.Instance.GridLayout.CellToLocalInterpolated(cellPos +
                new Vector3(0.5f, 0.5f, 0f));

                _prevPos = cellPos;
                GridBuildingSystem.Instance.FollowBuilding();
            }
    }

    private void OnMouseUp()
    {
        if (Placed) return;

        if (GridBuildingSystem.Instance.Temp.CanBePlaced())
        {
            GridBuildingSystem.Instance.Temp.Place();
        }
    }

    #endregion

    #region Build Method

    public bool CanBePlaced(){
        Vector3Int positionInt = GridBuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.Instance.CanTakeArea(areaTemp, gameObject)){
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
