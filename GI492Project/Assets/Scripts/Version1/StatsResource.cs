using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //public variable
    [HideInInspector] public static int TotalEnergy;
    [HideInInspector] public static int TotalWood;
    [HideInInspector] public static int TotalStone;
    [HideInInspector] public static int TotalCopper;
    [HideInInspector] public static int TotalIron;
    [HideInInspector] public static int TotalGold;

   // public GameObject check1;
   // public GameObject check2;
   // public GameObject check3;

   // public Button complete1;
   // public Button complete2;

  //  public string sceneName;


    #region Unity Method
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TotalWood = beginResource;
        TotalStone = beginResource;
    }

    private void Update()
    {
        energyText.text = "Energy: " + TotalEnergy.ToString();
        woodText.text = "Wood: " + TotalWood.ToString();
        stoneText.text = "Stone: " + TotalStone.ToString();
        copperText.text = "Copper: " + TotalCopper.ToString();
        ironText.text = "Iron: " + TotalIron.ToString();
        goldText.text = "Gold: " + TotalGold.ToString();
    }

    #endregion


    #region Custom Method

    public void SpawnGen(CostBuilding cost)
    {
        if (TotalWood < cost.CostWood || TotalStone < cost.CostStone || TotalCopper < cost.CostCopper || TotalIron < cost.CostIron || TotalGold < cost.CostGold)
        {
            Debug.Log("Insufficient Resource");
            GridBuildingSystem.Instance.IsSpawningObj = true;
            return;
        }
        TotalWood -= cost.CostWood;
        TotalStone -= cost.CostStone;
        TotalCopper -= cost.CostCopper;
        TotalIron -= cost.CostIron;
        TotalGold -= cost.CostGold;
        GridBuildingSystem.Instance.IsSpawningObj = false;
    }

    //public void Tier1()
   // { 
       
      //  if(TotalCopper >= 30)
        //{
         
          //TotalCopper -= 30;
        //  check1.SetActive(true);
         // complete1.enabled = false;
       // }
   // }

    //public void Tier2()
   // {
        
       // if(TotalIron >= 30)
      //  {
          
        //  TotalIron -= 30;  
       //   check2.SetActive(true);
        //  complete2.enabled = false;
      //  }
    //}

   // public void Tier3()
    //{
        
      //  if(TotalGold >= 30)
       //{
          
         // TotalGold -= 30;
         // check3.SetActive(true);
        //  SceneManager.LoadScene(sceneName);
       // }

   // }

    #endregion
}
