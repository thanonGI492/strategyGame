using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteTier : MonoBehaviour
{
    
    [SerializeField] private int Q_copper;
    [SerializeField] private int Q_iron;
    [SerializeField] private int Q_gold;

    [SerializeField] private GameObject quest;
    [SerializeField] private GameObject Q_tier1;
    [SerializeField] private GameObject Q_tier2;
    [SerializeField] private GameObject Q_tier3;

    [SerializeField] private GameObject check1;
    [SerializeField] private GameObject check2;
    [SerializeField] private GameObject check3;

    [SerializeField] private Button complete1;
    [SerializeField] private Button complete2;
    [SerializeField] private Button complete3;

    [SerializeField] private GameObject backgroundQuest2;
    [SerializeField] private GameObject backgroundQuest3;

    public string sceneName;

    //private variable
    private bool _isCompleteQuest1;
    private bool _isCompleteQuest2;
    private bool _isCompleteQuest3;

    void Start()
    {
        quest.SetActive(false);
        _isCompleteQuest1 = false;
        _isCompleteQuest2 = false;
        _isCompleteQuest3 = false;
        //Q_tier2.SetActive(false);
        //Q_tier3.SetActive(false);
    }

    private void Update()
    {
        if (!_isCompleteQuest1 || !_isCompleteQuest2 || !_isCompleteQuest3)
        {
            return;
        }
        SceneManager.LoadScene(sceneName);
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
        backgroundQuest2.SetActive(false);
        _isCompleteQuest1 = true;
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
        backgroundQuest3.SetActive(false);
        _isCompleteQuest2 = true;
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
        
        complete3.enabled = false;
        _isCompleteQuest3 = true;
    }
}
