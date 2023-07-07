using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public GameObject energypoint;
    public Text energyUI;
    public int CurRegen ;
    public float isTime = 1f;
    public int Pumper = 0;
    private float timer = 0f;
    private float isTimer = 0f;
    
    void Start()
    {
       energypoint = GameObject.Find("Energy point");
       energyUI = energypoint.GetComponent<Text>();
       //energyUI.text = CurRegen.ToString();
    }
   
    private void Update()
    {

        
        
        timer += Time.deltaTime;
        if (timer >= isTime)
        {
            CurRegen += Pumper;
            timer = isTimer;
            Debug.Log("Drain resource: " + CurRegen);
            energyUI.text = CurRegen.ToString();
            //if(CurRegen)
        }
        
    }
}
