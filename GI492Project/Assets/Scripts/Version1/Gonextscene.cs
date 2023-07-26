using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gonextscene : MonoBehaviour
{
    public string sceneNameNext1;
    public string sceneNameNext2;

    
    public void Nextscene1()
    {
        SceneManager.LoadScene(sceneNameNext1);
    }

    public void Nextscene2()
    {
        SceneManager.LoadScene(sceneNameNext2);
    }
}
