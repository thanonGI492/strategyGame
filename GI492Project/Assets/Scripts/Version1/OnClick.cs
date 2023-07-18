using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    [SerializeField] private GameObject destroyBtn;

    //private variable
    private Gens _gens;

    private void Awake()
    {
        _gens = GetComponent<Gens>();
    }

    private void Start()
    {
        destroyBtn.SetActive(false);
    }

    private void Update()
    {
        if (MouseHoverDestroyBtn.IsHovering)
        {
            destroyBtn.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (!BuildingSystem.Instance.Placed)
        {
            return;
        }

        destroyBtn.SetActive(true);
    }

    private void OnMouseExit()
    {
        destroyBtn.SetActive(false);
    }

    public void OnButtonClick()
    {
        StatsResource.TotalEnergy += _gens.Building.ReturnENG;
        StatsResource.TotalEnergy -= _gens.Building.DeductENG;
        MouseHoverDestroyBtn.IsHovering = false;
        Destroy(gameObject);
    }
}
