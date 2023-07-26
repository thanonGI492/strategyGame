using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoControl : MonoBehaviour
{
    [Header("Info")]
    //HowTo
    [SerializeField] private GameObject H_All;
    [SerializeField] private GameObject PreviosBT;
    [SerializeField] private GameObject NextBT;
    [SerializeField] private GameObject H1;
    [SerializeField] private GameObject H2;
    [SerializeField] private GameObject H3;

    [Header("Energy")]
    //Energy
    [SerializeField] private GameObject Energy_All;
    [SerializeField] private GameObject WM;
    [SerializeField] private GameObject TM;
    [SerializeField] private GameObject SC;
    [SerializeField] private GameObject HD;

    [Header("Building")]
    [SerializeField] private GameObject Building_All;
    [SerializeField] private GameObject Sawmill;
    [SerializeField] private GameObject Stonemine;
    [SerializeField] private GameObject Coppermine;
    [SerializeField] private GameObject Ironmine;
    [SerializeField] private GameObject Goldmine;
    
    // Start is called before the first frame update
    void Awake()
    {   
        H_All.SetActive(false);
        H1.SetActive(true);
        H2.SetActive(false);
        H3.SetActive(false);
        
    
        //Energy
        Energy_All.SetActive(false);
        WM.SetActive(false);
        TM.SetActive(false);
        SC.SetActive(false);
        HD.SetActive(false);
        
        //Building
        Building_All.SetActive(false);
        Sawmill.SetActive(false);
        Stonemine.SetActive(false);
        Coppermine.SetActive(false);
        Ironmine.SetActive(false);
        Goldmine.SetActive(false);
    }

    #region info

    public void OpenInfo()
    {
        H_All.SetActive(true);
        PreviosBT.SetActive(true);
        NextBT.SetActive(true);
        Energy_All.SetActive(false);
        Building_All.SetActive(false);
    }
    public void Previos()
    {
        if (H1.activeInHierarchy && H2.activeInHierarchy  && H3.activeInHierarchy == false)
        {
            H1.SetActive(true);
            H2.SetActive(false);
            H3.SetActive(false);
        }
        else if (H1.activeInHierarchy && H2.activeInHierarchy)
        {
            H3.SetActive(false);
        }
       
    }

    public void Next()
    {
        if (H2.activeInHierarchy == false )
        {
            H2.SetActive(true);
            H3.SetActive(false);
        }
        else 
        {
            H3.SetActive(true);
            
        }
         
    }
    #endregion

    #region EnergyInfo

    //Energy info
    public void OpenEnergy()
    {
        Energy_All.SetActive(true);
        H_All.SetActive(false);
        PreviosBT.SetActive(false);
        NextBT.SetActive(false);
        Building_All.SetActive(false);
        
    }
    public void WindMill()
    {
        WM.SetActive(true);
        TM.SetActive(false);
        SC.SetActive(false);
        HD.SetActive(false);
    }
    
    public void Thermal()
    {
        WM.SetActive(false);
        TM.SetActive(true);
        SC.SetActive(false);
        HD.SetActive(false);
    }
    
    public void Solarcell()
    {
        WM.SetActive(false);
        TM.SetActive(false);
        SC.SetActive(true);
        HD.SetActive(false);
    }
    
    public void Hydro()
    {
        WM.SetActive(false);
        TM.SetActive(false);
        SC.SetActive(false);
        HD.SetActive(true);
    }
    #endregion

    #region BuildingInfo

    public void OpenBuilding()
    {
        Building_All.SetActive(true);
        Energy_All.SetActive(false);
        H_All.SetActive(false);
        PreviosBT.SetActive(false);
        NextBT.SetActive(false);
        
    }
    public void SawMill()
    {
        Sawmill.SetActive(true);
        Stonemine.SetActive(false);
        Coppermine.SetActive(false);
        Ironmine.SetActive(false);
        Goldmine.SetActive(false);
    }
    
    public void Stone()
    {
        Sawmill.SetActive(false);
        Stonemine.SetActive(true);
        Coppermine.SetActive(false);
        Ironmine.SetActive(false);
        Goldmine.SetActive(false);
    }
    
    public void Copper()
    {
        Sawmill.SetActive(false);
        Stonemine.SetActive(false);
        Coppermine.SetActive(true);
        Ironmine.SetActive(false);
        Goldmine.SetActive(false);
    }
    
    public void Iron()
    {
        Sawmill.SetActive(false);
        Stonemine.SetActive(false);
        Coppermine.SetActive(false);
        Ironmine.SetActive(true);
        Goldmine.SetActive(false);
    }
    
    public void Gold()
    {
        Sawmill.SetActive(false);
        Stonemine.SetActive(false);
        Coppermine.SetActive(false);
        Ironmine.SetActive(false);
        Goldmine.SetActive(true);
    }

    #endregion
}
