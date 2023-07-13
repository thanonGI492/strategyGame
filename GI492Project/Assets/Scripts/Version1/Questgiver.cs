using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questgiver : MonoBehaviour
{
    public Questopen quest;

    public GameObject questlist;
    
    public void OpenQuestlist()
    {
        questlist.SetActive(true);
    }
    public void CloseQuestlist()
    {
        questlist.SetActive(false);
    }
}
