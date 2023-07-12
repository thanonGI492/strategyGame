using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool : MonoBehaviour
{
    [SerializeField] private int AddResource;
 
     public GameObject debug;   

     void Start()     
     {         
        debug.SetActive(false);              
     }     

        void Update()     
        {         
            if (Input.GetKeyDown(KeyCode.D) && debug.activeInHierarchy == false)         
            {             
                debug.SetActive(true);   

            }         
             else         
             {              
                if (Input.GetKeyDown(KeyCode.D))              
                {                  
                    debug.SetActive(false);              
                }         
                
             }
        }             
              
          
              

    public void newresource()
    {
        StatsResource.TotalWood += AddResource;
        StatsResource.TotalCopper += AddResource;
        StatsResource.TotalGold += AddResource;
        StatsResource.TotalIron += AddResource;
        StatsResource.TotalStone += AddResource;
    }
}
