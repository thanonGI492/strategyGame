using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Transform parentTrans;

    public bool Placed {get; private set;}

    [Header("Setting")]
    public BoundsInt area;

    //private Variable
    private Vector3 _offSet;
    private Vector3 _prevPos;
    private bool _collideObject;
    

    #region Unity Method

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
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
                GridBuildingSystem.Instance.FollowBuilding();
                
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
        else
        {
            if (floatingTextPrefab)
            {
                FloatingText();
            }
        }
    }

    private void FloatingText()
    { 
        GameObject floatText = Instantiate(floatingTextPrefab, transform.position, quaternion.identity, parentTrans);
        floatText.GetComponent<TextMeshPro>().text = "Place on: " + gameObject.tag;
    }

    private void Update()
    {
        Debug.Log(floatingTextPrefab);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<BuildingSystem>())
        {
            _collideObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _collideObject = false;
    }

    #endregion

    #region Build Method

    public bool CanBePlaced(){
        Vector3Int positionInt = GridBuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.Instance.CanTakeArea(areaTemp, gameObject) && !_collideObject){
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
