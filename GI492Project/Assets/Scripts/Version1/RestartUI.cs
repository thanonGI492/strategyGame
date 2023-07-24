using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUI : MonoBehaviour
{ 

    public void RestartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Version1");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
