using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingVersionTwo : MonoBehaviour
{
    public static BuildingVersionTwo Instance;

    [Header("Reference")]
    public GridLayout gridLayout;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase whiteTile;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;

    //private variable
    private Grid _grid;
    private PlaceableObject _objectToPlace;

    #region Unity Methods

    private void Awake(){
        Instance = this;

        _grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)){
            InitializeWithObject(prefab1);
        }
        else if (Input.GetKeyDown(KeyCode.B)){
            InitializeWithObject(prefab2);
        }
    }
    #endregion

    #region Utils

    public Vector3 SnapCoodinateToGrid(Vector3 position){
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = _grid.GetCellCenterWorld(cellPos);
        return position;
    }

    #endregion

    #region Building Placement

    public void InitializeWithObject(GameObject prefab){
        Vector3 position = SnapCoodinateToGrid(Vector3.zero);
        
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        _objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    #endregion

}
