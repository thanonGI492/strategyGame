using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteTier : MonoBehaviour
{
    [SerializeField] private GameObject quest;
    public int TotalCopper22;
    public int TotalIron22;
    public int TotalGold22;
    public int Q_copper;
    public int Q_iron;
    public int Q_gold;
    public GameObject Q_tier1;
    public GameObject Q_tier2;
    public GameObject Q_tier3;

    //[SerializeField] GameObject stats;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;

    public Button complete1;
    public Button complete2;
    public Button complete3;

    public string sceneName;

    void Start()
    {
        quest.SetActive(false);
        Q_tier2.SetActive(false);
        Q_tier3.SetActive(false);
    }

    void Update()
    {
        TotalCopper22 = StatsResource.TotalCopper;
        TotalIron22 = StatsResource.TotalIron;
        TotalGold22 = StatsResource.TotalGold;
    }
    
    public void Tier1()
    { 
        
        if(TotalCopper22 >= Q_copper)
        {
          StatsResource.TotalCopper -= Q_copper;
          check1.SetActive(true);
          complete1.enabled = false;
          Q_tier2.SetActive(true);
        }
    }

    public void Tier2()
    {
        
        if(TotalIron22 >= Q_iron)
        {
          
          StatsResource.TotalIron -= Q_iron;  
          check2.SetActive(true);
          complete2.enabled = false;
          Q_tier3.SetActive(true);
        }
    }

    public void Tier3()
    {
        
        if(TotalGold22 >= Q_gold)
        {
          
          StatsResource.TotalGold -= Q_gold;
          check3.SetActive(true);
          complete3.enabled = false;
          SceneManager.LoadScene(sceneName);
        }

    }
}
