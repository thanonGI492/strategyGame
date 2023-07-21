using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem Instance;

    [Header("References")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GridLayout gridLayout;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;
    [SerializeField] private CostBuilding[] building;

    public GridLayout GridLayout => gridLayout;
    public BuildingSystem Temp => temp;
    [HideInInspector] public bool IsSpawningObj;
    [HideInInspector] public bool IsAlreadyOccupied;

    //Private Variable
    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();
    private BuildingSystem temp;
    private BoundsInt prevArea;

    #region Unity Methods
    
    private void Awake(){
        Instance = this;
    }

    private void Start() {
        foreach (var t in tileBases.Keys)
        {
            if (t.Equals(TileType.Empty) || t.Equals(TileType.Dirt) || t.Equals(TileType.Dirt2) ||
                t.Equals(TileType.Dirt3) || t.Equals(TileType.Dirt4) || t.Equals(TileType.Red) ||
                t.Equals(TileType.Forest) || t.Equals(TileType.Forest2) || t.Equals(TileType.Water) ||
                t.Equals(TileType.Copper) || t.Equals(TileType.Iron) || t.Equals(TileType.Gold) ||
                t.Equals(TileType.Hill) || t.Equals(TileType.Hill2) || t.Equals(TileType.Stone) ||
                t.Equals(TileType.Stone2) || t.Equals(TileType.TreeDestroy) || t.Equals(TileType.StoneDestroy))
            {
                return;
            }
        }
        string version = @"Version1\";
        string tilePath = @"Tiles\";

        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.Dirt, Resources.Load<TileBase>(version + tilePath + "dirt"));
        tileBases.Add(TileType.Dirt2, Resources.Load<TileBase>(version + tilePath + "dirt2"));
        tileBases.Add(TileType.Dirt3, Resources.Load<TileBase>(version + tilePath + "dirt3"));
        tileBases.Add(TileType.Dirt4, Resources.Load<TileBase>(version + tilePath + "dirt4"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>(version + tilePath + "red"));
        tileBases.Add(TileType.Forest, Resources.Load<TileBase>(version + tilePath + "forest"));
        tileBases.Add(TileType.Forest2, Resources.Load<TileBase>(version + tilePath + "forest2"));
        tileBases.Add(TileType.Water, Resources.Load<TileBase>(version + tilePath + "water"));
        tileBases.Add(TileType.Copper, Resources.Load<TileBase>(version + tilePath + "copper"));
        tileBases.Add(TileType.Iron, Resources.Load<TileBase>(version + tilePath + "iron"));
        tileBases.Add(TileType.Gold, Resources.Load<TileBase>(version + tilePath + "gold"));
        tileBases.Add(TileType.Hill, Resources.Load<TileBase>(version + tilePath + "hill"));
        tileBases.Add(TileType.Hill2, Resources.Load<TileBase>(version + tilePath + "hill2"));
        tileBases.Add(TileType.Stone, Resources.Load<TileBase>(version + tilePath + "stone"));
        tileBases.Add(TileType.Stone2, Resources.Load<TileBase>(version + tilePath + "stone2"));
        tileBases.Add(TileType.TreeDestroy, Resources.Load<TileBase>(version + tilePath + "treeDestroy"));
        tileBases.Add(TileType.StoneDestroy, Resources.Load<TileBase>(version + tilePath + "StoneDestroy"));
        tileBases.Add(TileType.CopperDestroy, Resources.Load<TileBase>(version + tilePath + "copperDestroy"));
        tileBases.Add(TileType.IronDestroy, Resources.Load<TileBase>(version + tilePath + "ironDestroy"));
        tileBases.Add(TileType.GoldDestroy, Resources.Load<TileBase>(version + tilePath + "goldDestroy"));
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
                foreach (var b in building)
                {
                    if (b.NameBuilding == temp.GetComponent<Gens>().Building.NameBuilding)
                    {
                        StatsResource.TotalWood += b.CostWood;
                        StatsResource.TotalStone += b.CostStone;
                        StatsResource.TotalCopper += b.CostCopper;
                        StatsResource.TotalIron += b.CostIron;
                    }
                }
                IsSpawningObj = false;
                StatsResource.Instance.WaitingPlace = false;
                ClearArea();
                Destroy(temp.gameObject);
            }
            
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

        IsSpawningObj = true;
        temp = Instantiate(building, new Vector3(cam.transform.position.x, cam.transform.position.y), Quaternion.identity).GetComponent<BuildingSystem>();
        FollowBuilding(temp.gameObject);
    }

    public void ClearArea(){
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        tempTilemap.SetTilesBlock(prevArea, toClear);
    }
    
    public void FollowBuilding(GameObject gameObject){
        ClearArea();

        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, mainTilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < baseArray.Length; i++) {
            if (baseArray[i] == tileBases[TileType.Dirt] && gameObject.CompareTag("OnDirt") || baseArray[i] == tileBases[TileType.Dirt2] && gameObject.CompareTag("OnDirt") || 
                baseArray[i] == tileBases[TileType.Dirt3] && gameObject.CompareTag("OnDirt") || baseArray[i] == tileBases[TileType.Dirt4] && gameObject.CompareTag("OnDirt") || 
                baseArray[i] == tileBases[TileType.Hill] && gameObject.CompareTag("OnHill")|| baseArray[i] == tileBases[TileType.Water] && gameObject.CompareTag("OnWater") || 
                baseArray[i] == tileBases[TileType.Stone] && gameObject.CompareTag("OnStone")|| baseArray[i] == tileBases[TileType.Forest] && gameObject.CompareTag("OnForest") ||
                baseArray[i] == tileBases[TileType.Forest2] && gameObject.CompareTag("OnForest") || baseArray[i] == tileBases[TileType.Copper] && gameObject.CompareTag("OnCopper") || 
                baseArray[i] == tileBases[TileType.Iron] && gameObject.CompareTag("OnIron") || baseArray[i] == tileBases[TileType.Gold] && gameObject.CompareTag("OnGold") ||
                baseArray[i] == tileBases[TileType.Stone2] && gameObject.CompareTag("OnStone") || baseArray[i] == tileBases[TileType.Hill2] && gameObject.CompareTag("OnHill"))
            {
                IsAlreadyOccupied = false;
                tileArray[i] = tileBases[TileType.TreeDestroy];
            }
            else
            {
                IsAlreadyOccupied = true;
                FillTiles(tileArray, TileType.Red);
                break;
            }
        }

        tempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    public bool CanTakeArea(BoundsInt area){
        TileBase[] baseArray = GetTilesBlock(area, mainTilemap);
        foreach (var b in baseArray){
            if ((b == tileBases[TileType.Dirt]) || (b == tileBases[TileType.Forest]) ||
                (b == tileBases[TileType.Hill]) || (b == tileBases[TileType.Stone]) ||
                (b == tileBases[TileType.Copper]) || (b == tileBases[TileType.Iron]) ||
                (b == tileBases[TileType.Water]) || (b == tileBases[TileType.Gold]) ||
                (b == tileBases[TileType.Dirt2]) || (b == tileBases[TileType.Dirt3]) ||
                (b == tileBases[TileType.Dirt4]) || (b == tileBases[TileType.Forest2]) ||
                (b == tileBases[TileType.Stone2]) || (b == tileBases[TileType.Hill2]))
            {
                return true;
            } 
        }
        return false;
    }

    public void TakeArea(BoundsInt area) {
        SetTilesBlock(area, TileType.Empty, tempTilemap);
        TileBase[] baseArray = GetTilesBlock(area, mainTilemap);
        
        foreach (var b in baseArray)
        {
            if (b == tileBases[TileType.Dirt] || b == tileBases[TileType.Dirt2] || b == tileBases[TileType.Dirt3] ||
                b == tileBases[TileType.Dirt4] || b == tileBases[TileType.Hill] || b == tileBases[TileType.Hill2] || 
                b == tileBases[TileType.Water])
            {
                return;
            }
            SetTilesBlock(area, TileType.Empty, mainTilemap);

            if (b == tileBases[TileType.Forest] || b == tileBases[TileType.Forest2])
            {
                SetTilesBlock(area, TileType.TreeDestroy, mainTilemap);
            }
            else if (b == tileBases[TileType.Stone] || b == tileBases[TileType.Stone2])
            {
                SetTilesBlock(area, TileType.StoneDestroy, mainTilemap);
            }
            else if (b == tileBases[TileType.Copper])
            {
                SetTilesBlock(area, TileType.CopperDestroy, mainTilemap);
            }
            else if (b == tileBases[TileType.Iron])
            {
                SetTilesBlock(area, TileType.IronDestroy, mainTilemap);
            }
            else if (b == tileBases[TileType.Gold])
            {
                SetTilesBlock(area, TileType.GoldDestroy, mainTilemap);
            }
        }
    }

    #endregion

}

public enum TileType{
    Empty,
    Dirt,
    Dirt2,
    Dirt3,
    Dirt4,
    Forest,
    Forest2,
    Red,
    Water,
    Copper,
    Iron,
    Gold,
    Hill,
    Hill2,
    Stone,
    Stone2,
    TreeDestroy,
    StoneDestroy,
    CopperDestroy,
    IronDestroy,
    GoldDestroy
}
