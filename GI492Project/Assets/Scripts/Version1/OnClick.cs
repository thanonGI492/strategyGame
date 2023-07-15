using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    
    private Camera camera;
    public GameObject _destroyBotton;
    private GameObject _ourGameObj;
    public float _waitTime;
    public CostBuilding[] _Buildings;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        _destroyBotton.SetActive(false);
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
                if (_ourGameObj.GetComponent<BuildingSystem>().Placed)
                {
                    _destroyBotton.SetActive(true);
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
    }

    public IEnumerator onOpen()
    {
        yield return new WaitForSeconds(_waitTime);
        _destroyBotton.SetActive(false);
    }

    
}
