using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questgiver : MonoBehaviour
{
    public Quest quest;

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
