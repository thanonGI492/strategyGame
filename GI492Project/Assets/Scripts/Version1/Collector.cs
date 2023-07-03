using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int CurRegen = 0;
    private float timer = 0f;
  
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            CurRegen += 1;
            timer = 0f;
            Debug.Log("Drain resource: " + CurRegen);
        }
    }
}
