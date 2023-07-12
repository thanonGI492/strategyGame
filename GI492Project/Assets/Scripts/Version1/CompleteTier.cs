using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteTier : MonoBehaviour
{
    StatsResource statsresource;
    
   // public GameObject TotalCopper2;
   // public GameObject TotalIron2;
   // public GameObject TotalGold2;
    public Text copperText2;
    public Text ironText2;
    public Text goldText2;
    public int TotalCopper22;
    public int TotalIron22;
    public int TotalGold22;

    //[SerializeField] GameObject stats;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;

    public Button complete1;
    public Button complete2;

    public string sceneName;

    void Start()
    {
        
        //TotalCopper2 = GameObject.Find("Copper");
        //TotalIron2 = GameObject.Find("Iron");
       // TotalGold2 = GameObject.Find("Gold");
        //copperText2 = TotalCopper2.GetComponent<Text>();
       // ironText2 = TotalIron2.GetComponent<Text>();
       // goldText2 = TotalGold2.GetComponent<Text>();
    }

   //void Awake()
    //{
      //  statsresource = stats.GetComponent<StatsResource>();
    //}

    void Update()
    {
        //TotalCopper = TotalCopper22;
        //TotalIron = TotalIron22;
        //TotalGold = TotalGold22;
        copperText2.text = "Copper: " + TotalCopper22.ToString();
        ironText2.text = "Iron: " + TotalIron22.ToString();
        goldText2.text = "Gold: " + TotalGold22.ToString();
    }
    
    public void Tier1()
    { 
       
        if(TotalCopper22 >= 30)
        {
         
          TotalCopper22 -= 30;
          check1.SetActive(true);
          complete1.enabled = false;
        }
    }

    public void Tier2()
    {
        
        if(TotalIron22 >= 30)
        {
          
          TotalIron22 -= 30;  
          check2.SetActive(true);
          complete2.enabled = false;
        }
    }

    public void Tier3()
    {
        
        if(TotalGold22 >= 30)
        {
          
          TotalGold22 -= 30;
          check3.SetActive(true);
          SceneManager.LoadScene(sceneName);
        }

    }
}
