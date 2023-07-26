using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private GameObject retryHolder;
    [SerializeField] private GameObject popup1;
    [SerializeField] private GameObject popup2;
    [SerializeField] private GameObject infoHoleder;
    [SerializeField] private GameObject Tutorial;

    public float waitOpen;
    
    
    

    private void Start()
    {
        StartCoroutine(WaitTime());
        
        if (Tutorial.activeInHierarchy)
        {
            
            Time.timeScale = 0;
        }
        else if(Tutorial.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }

    }

    public void No()
    {
        Tutorial.SetActive(false);

    }

    private void Awake()
    {
        infoHoleder.SetActive(false);
        retryHolder.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        retryHolder.SetActive(true);

        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        retryHolder.SetActive(false);

        Time.timeScale = 1;
    }
    
    public void Showpopup1()
    {
        popup1.SetActive(true);
        popup2.SetActive(false);
    }

    public void Showpopup2()
    {
        popup1.SetActive(false);
        popup2.SetActive(true);
    }
    
    //InfoPaused 
    public void PauseGameInfo()
    {
        infoHoleder.SetActive(true);
        Tutorial.SetActive(false);
        Time.timeScale = 0;
    }
    
    public void UnPauseGameInfo()
    {
        infoHoleder.SetActive(false);

        Time.timeScale = 1;
    }

    IEnumerator WaitTime()
    {
        yield return new  WaitForSeconds(waitOpen);
        Tutorial.SetActive(true);
        
    }
}
