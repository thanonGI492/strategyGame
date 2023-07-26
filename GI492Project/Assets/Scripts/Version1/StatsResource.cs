using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsResource : MonoBehaviour
{
    public static StatsResource Instance;

    [SerializeField] private Text energyText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text stoneText;
    [SerializeField] private Text copperText;
    [SerializeField] private Text ironText;
    [SerializeField] private Text goldText;
    [SerializeField] private int beginResource;
    [SerializeField] private int resetResource;
    [SerializeField] private GameObject floatTextPrefab;
    [SerializeField] private GameObject cam;
    [SerializeField] private int offSet;

    //public variable
    [HideInInspector] public static int TotalEnergy;
    [HideInInspector] public static int TotalWood;
    [HideInInspector] public static int TotalStone;
    [HideInInspector] public static int TotalCopper;
    [HideInInspector] public static int TotalIron;
    [HideInInspector] public static int TotalGold;
    [HideInInspector] public bool WaitingPlace;
    public GameObject FloatTextPrefab => floatTextPrefab;

    #region Unity Method
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TotalEnergy = resetResource;
        TotalWood = beginResource;
        TotalStone = beginResource;
        TotalCopper = resetResource;
        TotalIron = resetResource;
        TotalGold = resetResource;
    }

    private void Update()
    {
        energyText.text = " " + TotalEnergy.ToString();
        woodText.text = " " + TotalWood.ToString();
        stoneText.text = " " + TotalStone.ToString();
        copperText.text = " " + TotalCopper.ToString();
        ironText.text = " " + TotalIron.ToString();
        goldText.text = " " + TotalGold.ToString();
    }

    #endregion


    #region Custom Method

    public void SpawnGen(CostBuilding cost)
    {
        if (WaitingPlace)
        {
            return;
        }

        if (TotalWood < cost.CostWood || TotalStone < cost.CostStone || TotalCopper < cost.CostCopper || TotalIron < cost.CostIron)
        {
            FloatingText("Not Enough " , " Resource!");
            GridBuildingSystem.Instance.IsSpawningObj = true;
            return;
        }
        TotalWood -= cost.CostWood;
        TotalStone -= cost.CostStone;
        TotalCopper -= cost.CostCopper;
        TotalIron -= cost.CostIron;
        TotalGold -= cost.CostGold;
        WaitingPlace = true;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    public void FloatingText(string changeMessage, string message)
    {
        GameObject floatText = Instantiate(floatTextPrefab, new Vector3(cam.transform.position.x, cam.transform.position.y - offSet), Quaternion.identity, cam.transform);
        floatText.GetComponent<TextMesh>().text = changeMessage + message;
    }

    #endregion
}
