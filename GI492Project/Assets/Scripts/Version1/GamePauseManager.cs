using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private GameObject retryHolder;
    [SerializeField] private GameObject popup1;
    [SerializeField] private GameObject popup2;

    


    private void Awake()
    {
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


}
