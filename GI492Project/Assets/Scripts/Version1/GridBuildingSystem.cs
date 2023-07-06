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
    public bool IsSpawningObj;

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
        tileBases.Add(TileType.White, Resources.Load<TileBase>(version + tilePath + "white"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>(version + tilePath + "red"));
        tileBases.Add(TileType.Green, Resources.Load<TileBase>(version + tilePath + "green"));
        tileBases.Add(TileType.Blue, Resources.Load<TileBase>(version + tilePath + "blue"));
    }

    private void Update(){
        if (!temp)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ClearArea();
            Destroy(temp.gameObject);
        }
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
        temp = Instantiate(building, new Vector3(0f, 0.3f, 0f), Quaternion.identity).GetComponent<BuildingSystem>();
        FollowBuilding();
        IsSpawningObj = true;
    }

    private void ClearArea(){
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
            if (baseArray[i] == tileBases[TileType.White]){
                tileArray[i] = tileBases[TileType.Green];
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
            if (b == tileBases[TileType.White] && gameObject.CompareTag("OnWhite")){
                return true;
            } 
            else if (b == tileBases[TileType.Green] && gameObject.CompareTag("OnGreen")){
                return true;
            }
            else if (b == tileBases[TileType.Blue] && gameObject.CompareTag("OnBlue"))
            {
                return true;
            }
        }
        Debug.Log("Can't place here! Place on: " + gameObject.tag + " tile");
        return false;
    }

    public void TakeArea(BoundsInt area){
        SetTilesBlock(area, TileType.Empty, tempTilemap);
        if (gameObject.CompareTag("OnWhite"))
        {
            SetTilesBlock(area, TileType.Empty, mainTilemap);
        }
        else if (gameObject.CompareTag("OnGreen"))
        {
            SetTilesBlock(area, TileType.Empty, mainTilemap);
        }
        else if (gameObject.CompareTag("OnBlue"))
        {
            SetTilesBlock(area, TileType.Empty, mainTilemap);
        }
    }

    #endregion

}

public enum TileType{
    Empty,
    White,
    Green,
    Red,
    Blue
}
