using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem Instance;

    [Header("References")]
    [SerializeField] private GridLayout gridLayout;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;

    public GridLayout GridLayout => gridLayout;
    public BuildingSystem Temp => temp;
    [HideInInspector] public bool IsSpawningObj;

    //Private Variable
    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();
    private BuildingSystem temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;

    #region Unity Methods
    
    private void Awake(){
        Instance = this;
    }

    private void Start(){
        string version = @"Version1\";
        string tilePath = @"Tiles\";
        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.Dirt, Resources.Load<TileBase>(version + tilePath + "dirt"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>(version + tilePath + "red"));
        tileBases.Add(TileType.Forest, Resources.Load<TileBase>(version + tilePath + "forest"));
        tileBases.Add(TileType.Water, Resources.Load<TileBase>(version + tilePath + "water"));
        tileBases.Add(TileType.Copper, Resources.Load<TileBase>(version + tilePath + "copper"));
        tileBases.Add(TileType.Iron, Resources.Load<TileBase>(version + tilePath + "iron"));
        tileBases.Add(TileType.Gold, Resources.Load<TileBase>(version + tilePath + "gold"));
        tileBases.Add(TileType.Hill, Resources.Load<TileBase>(version + tilePath + "hill"));
        tileBases.Add(TileType.Stone, Resources.Load<TileBase>(version + tilePath + "stone"));
    }

    private void Update(){
        if (!temp)
        {
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (!BuildingSystem.Instance.Placed)
            {
                IsSpawningObj = false;
                ClearArea();
                Destroy(temp.gameObject);
            }
            
        }
        
        Debug.Log(IsSpawningObj);
    }

    #endregion

    #region Tiles MapManagement

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap){
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin){
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }

    private static void FillTiles(TileBase[] arr, TileType type){
        for (int i = 0; i < arr.Length; i++){
            arr[i] = tileBases[type];
        }
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap){
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }

    #endregion

    #region Building Placement

    public void InitializeWithBuilding(GameObject building){
        if (IsSpawningObj)
        {
            return;
        }

        IsSpawningObj = true;
        temp = Instantiate(building, new Vector3(0f, 0.3f, 0f), Quaternion.identity).GetComponent<BuildingSystem>();
        FollowBuilding();
        

    }

    public void ClearArea(){
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        tempTilemap.SetTilesBlock(prevArea, toClear);
    }
    
    public void FollowBuilding(){
        ClearArea();

        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, mainTilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < baseArray.Length; i++) {
            if (baseArray[i] == tileBases[TileType.Dirt]){
                tileArray[i] = tileBases[TileType.Forest];
            }
            else{
                FillTiles(tileArray, TileType.Red);
                break;
            }
        }

        tempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    public bool CanTakeArea(BoundsInt area, GameObject gameObject){
        TileBase[] baseArray = GetTilesBlock(area, mainTilemap);
        foreach (var b in baseArray){
            if (b == tileBases[TileType.Dirt] && gameObject.CompareTag("OnDirt")){
                return true;
            } 
            else if (b == tileBases[TileType.Forest] && gameObject.CompareTag("OnForest")){
                return true;
            }
            else if (b == tileBases[TileType.Water] && gameObject.CompareTag("OnWater"))
            {
                return true;
            }
            else if (b == tileBases[TileType.Copper] && gameObject.CompareTag("OnCopper"))
            {
                return true;
            }
            else if (b == tileBases[TileType.Iron] && gameObject.CompareTag("OnIron"))
            {
                return true;
            }
            else if (b == tileBases[TileType.Gold] && gameObject.CompareTag("OnGold"))
            {
                return true;
            }
            else if (b == tileBases[TileType.Hill] && gameObject.CompareTag("OnHill"))
            {
                return true;
            }
            else if (b == tileBases[TileType.Stone] && gameObject.CompareTag("OnStone"))
            {
                return true;
            }
        }
        Debug.Log("Can't place here! Place on: " + gameObject.tag + " tile");
        return false;
    }

    public void TakeArea(BoundsInt area){
        SetTilesBlock(area, TileType.Empty, tempTilemap);
    }

    #endregion

}

public enum TileType{
    Empty,
    Dirt,
    Forest,
    Red,
    Water,
    Copper,
    Iron,
    Gold,
    Hill,
    Stone
}
