using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackOutTime : MonoBehaviour
{
    [SerializeField] private GameObject Blackout;
    [SerializeField] private Text _blackout;
    private float timer;
    public int _blackoutTime;
    public int _curTime;
    public int _timecout;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Blackout.SetActive(false);
        _curTime = _blackoutTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (StatsResource.TotalEnergy <= -1)
        {
           Blackout.SetActive(true);
           timer += Time.deltaTime;
           if (timer >= _timecout)
           {
               _curTime -= _timecout;
               timer -= _timecout;
           }
            _blackout.text = "BlackOut : " + _curTime;
        }

        if (StatsResource.TotalEnergy >= 0 && Blackout.activeInHierarchy == true)
        {
            _curTime = _blackoutTime;
            Blackout.SetActive(false);

        }

        if (_curTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
