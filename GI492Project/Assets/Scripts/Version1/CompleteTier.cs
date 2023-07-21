using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteTier : MonoBehaviour
{
    
    public int Q_copper;
    public int Q_iron;
    public int Q_gold;

    public GameObject quest;
    public GameObject Q_tier1;
    public GameObject Q_tier2;
    public GameObject Q_tier3;

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

    public void Tier1()
    {
        if(StatsResource.TotalCopper < Q_copper)
        {
            StatsResource.Instance.FloatingText("Not Enough ","Resources");
            return;
        }
        StatsResource.TotalCopper -= Q_copper;
        check1.SetActive(true);
        complete1.enabled = false;
        Q_tier2.SetActive(true);
    }

    public void Tier2()
    {
        if(StatsResource.TotalIron < Q_iron)
        {
            StatsResource.Instance.FloatingText("Not Enough ","Resources");
            return;
        }
        StatsResource.TotalIron -= Q_iron;  
        check2.SetActive(true);
        complete2.enabled = false;
        Q_tier3.SetActive(true);
    }

    public void Tier3()
    {
        
        if(StatsResource.TotalGold < Q_gold)
        {
            StatsResource.Instance.FloatingText("Not Enough ","Resources");
            return;
        }
        StatsResource.TotalGold -= Q_gold;
        check3.SetActive(true);
        SceneManager.LoadScene(sceneName);
        complete3.enabled = false;

    }
}
