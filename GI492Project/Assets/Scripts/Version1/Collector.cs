using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int CurRegen = 0;
    public float isTime = 1f;
    public int Pumper = 0;
    private float timer = 0f;
    private float isTimer = 0f;
  
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= isTime)
        {
            CurRegen += Pumper;
            timer = isTimer;
            Debug.Log("Drain resource: " + CurRegen);
        }
    }
}
