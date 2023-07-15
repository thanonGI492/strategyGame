using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class OnClick : MonoBehaviour
{
    [SerializeField] private TMP_Text InfoText;
    [SerializeField] private float TimeUpdate;
    public GameObject Infoholder;
    public GameObject _InfoBotton;
    public GameObject _CloseBotton;
    private Camera camera;
    public GameObject _destroyBotton;
    private GameObject _ourGameObj;
    public float _waitTime;
    public float _infotime;
    public CostBuilding[] _Buildings;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        _destroyBotton.SetActive(false);
        _InfoBotton.SetActive(false);
        Infoholder.SetActive(false);
        _CloseBotton.SetActive(false);
        
       


    }

    // Update is called once per frame
    void Update()
    {
        DetectObjectWithRaycast();

       
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) || _destroyBotton == false)
            {
                _ourGameObj = hit.collider.gameObject;
                Debug.Log ("object that was hit: " + _ourGameObj);
                if (_ourGameObj.GetComponent<BuildingSystem>().Placed)
                {
                    _destroyBotton.SetActive(true);
                    _InfoBotton.SetActive(true);
                    Infoholder.SetActive(false);
                    _CloseBotton.SetActive(false);
                    
                    
                }
                
            }
            else
            {
                
                StartCoroutine(onOpen());
            }
            
            
        }
    }

    public void DestroyST()
    {
        foreach (var B in _Buildings)
        {
            if (B.NameBuilding == _ourGameObj.GetComponent<Gens>().Building.NameBuilding)
            {
                StatsResource.TotalEnergy += B.ReturnENG;
                StatsResource.TotalEnergy -= B.DeductENG;
                Debug.Log(_ourGameObj.GetComponent<Gens>().Building.NameBuilding);
            }
            
        }
        
        Destroy(_ourGameObj);
        _destroyBotton.SetActive(false);
        _InfoBotton.SetActive(false);
    }
    
    public void Infomation()
    {
        Infoholder.SetActive(true);
        foreach (var B in _Buildings)
        {
            if (B.NameBuilding == _ourGameObj.GetComponent<Gens>().Building.NameBuilding)
            {
                switch (B.NameBuilding)
                {
                    case "Solar":
                    case "Hydroelectricplant":
                    case "Windmill":
                        StartCoroutine(TextUpdateEnergy());
                        break;
                    case "Sawmill":
                        StartCoroutine(TextUpdateWood());
                        break;
            
                    case "Stonemine":
                        StartCoroutine(TextUpdateStone());
                        break;
                    case "Coppermine":
                        StartCoroutine(TextUpdateCopper());
                        break;
                    case "Ironmine":
                        StartCoroutine(TextUpdateIron());
                        break;
                    case "Goldmine":
                        StartCoroutine(TextUpdateGold());
                        break;
                    case "Thermalplant":
                        StartCoroutine(TextUpdateThermal());
                        break;
                }
                _CloseBotton.SetActive(true);
                _InfoBotton.SetActive(false);


            }
            
        }
       
       
    }

    public IEnumerator onOpen()
    {
        yield return new WaitForSeconds(_waitTime);
        _destroyBotton.SetActive(false);
        
    }

    public void Closeinfo()
    {
        _CloseBotton.SetActive(false);
        Infoholder.SetActive(false);
        Debug.Log("IsClose");

    }

    #region TextUpdate

    

        
    IEnumerator TextUpdateEnergy()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var E = _ourGameObj.GetComponent<Gens>().Building.DeductENG;
        InfoText.text = B + "\n" + "Energy = +" + E ;
        StartCoroutine(TextUpdateEnergy());
        yield break;
    }

    IEnumerator TextUpdateWood()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var R = _ourGameObj.GetComponent<Gens>().Building.ReturnENG;
        var W = _ourGameObj.GetComponent<Gens>().OnGenswood;
        InfoText.text = B + "\n" + "Wood Current = " + W + "\n" + "UseEnergy = " + R;
        StartCoroutine(TextUpdateWood());
        yield break;
        
    }
    
    IEnumerator TextUpdateStone()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var R = _ourGameObj.GetComponent<Gens>().Building.ReturnENG;
        var S = _ourGameObj.GetComponent<Gens>().OnGensstone;
        
        InfoText.text = B + "\n" + "Stone Current = " + S + "\n" + "UseEnergy = " + R;
        StartCoroutine(TextUpdateStone());
        yield break;
        
    }
    
    IEnumerator TextUpdateCopper()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var R = _ourGameObj.GetComponent<Gens>().Building.ReturnENG;
        var C = _ourGameObj.GetComponent<Gens>().OnGenscopper;
        
        InfoText.text = B + "\n" + "Copper Current = " + C + "\n" + "UseEnergy = " + R;
        StartCoroutine(TextUpdateCopper());
        yield break;
        
    }
    
    IEnumerator TextUpdateIron()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var R = _ourGameObj.GetComponent<Gens>().Building.ReturnENG;
        var I = _ourGameObj.GetComponent<Gens>().OnGensiron;
        
        InfoText.text = B + "\n" + "Copper Current = " + I + "\n" + "UseEnergy = " + R;
        StartCoroutine(TextUpdateIron());
        yield break;
        
    }
    
    IEnumerator TextUpdateGold()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var R = _ourGameObj.GetComponent<Gens>().Building.ReturnENG;
        var G = _ourGameObj.GetComponent<Gens>().OnGensgold;
        
        InfoText.text = B + "\n" + "Copper Current = " + G + "\n" + "UseEnergy = " + R;
        StartCoroutine(TextUpdateGold());
        yield break;
        
    }
    
    IEnumerator TextUpdateThermal()
    {
        yield return new WaitForSeconds(TimeUpdate);
        var B = _ourGameObj.GetComponent<Gens>().Building.NameBuilding;
        var E = _ourGameObj.GetComponent<Gens>().Building.DeductENG;
        var R = _ourGameObj.GetComponent<Gens>().Building.ReturnENG;
        var T = _ourGameObj.GetComponent<Gens>().Thermal;
        
        InfoText.text = B + "\n" + "Energy = +" + E ;
        InfoText.text = B + "\n" + "DrainWood = " + T +  "\n" + "UseEnergy = " + R;
        StartCoroutine(TextUpdateThermal());
        yield break;
        
    }
    #endregion
}
