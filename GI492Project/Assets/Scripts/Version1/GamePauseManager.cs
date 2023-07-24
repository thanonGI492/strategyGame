using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private GameObject retryHolder;

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
}
