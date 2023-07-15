using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;
    [SerializeField] private Color rightTile;
    [SerializeField] private Color wrongTile;

    public bool Placed {get; private set;}

    [Header("Setting")]
    public BoundsInt area;

    //private Variable
    private Vector3 _offSet;
    private Vector3 _prevPos;
    private SpriteRenderer _spriteRend;
    

    #region Unity Method

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseDown(){
        _offSet = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag(){

        if (Placed) return;

        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offSet;
        Vector3Int cellPos = GridBuildingSystem.Instance.GridLayout.LocalToCell(touchPos);
        
        if (_prevPos != cellPos)
        {
                GridBuildingSystem.Instance.Temp.transform.localPosition = GridBuildingSystem.Instance.GridLayout.CellToLocalInterpolated(cellPos +
                new Vector3(0.5f, 0.5f, 0f));

                _prevPos = cellPos;
                GridBuildingSystem.Instance.FollowBuilding(gameObject);
                
        }
    }

    private void OnMouseUp()
    {
        if (Placed) return;

        if (GridBuildingSystem.Instance.Temp.CanBePlaced())
        {
            GridBuildingSystem.Instance.Temp.Place();
            StatsResource.Instance.WaitingPlace = false;
        }
        else if(StatsResource.Instance.FloatTextPrefab)
        { 
            StatsResource.Instance.FloatingText("Place: ", gameObject.tag);
        }
    }

    #endregion

    #region Build Method

    public bool CanBePlaced(){
        Vector3Int positionInt = GridBuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.Instance.CanTakeArea(areaTemp) && !CheckCollideObject.CollideObject && !GridBuildingSystem.Instance.IsAlreadyOccupied){
            _spriteRend.color = rightTile;
            return true;
        }
        _spriteRend.color = wrongTile;
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
