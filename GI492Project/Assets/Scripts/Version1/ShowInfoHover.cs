using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInfoHover : MonoBehaviour
{
    [Header("Refernece")]
    [SerializeField] private GameObject uiHolder;
    [SerializeField] private TMP_Text infoText;

    //private variable
    private Gens objectRefernce;
    private bool _mouseExit;

    private void Awake()
    {
        objectRefernce = GetComponent<Gens>();
    }

    private void Start()
    {
        uiHolder.SetActive(false);
    }

    private void Update()
    {
        if (!_mouseExit)
        {
            return;
        }
        uiHolder.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (!BuildingSystem.Instance.Placed)
        {
            return;
        }
        uiHolder.SetActive(true);
        
        switch (objectRefernce.Building.NameBuilding)
        {
            case "Sawmill":
                infoText.text = "Current Woods: " + objectRefernce.OnGenswood.ToString();
                break;
            case "Stonemine":
                infoText.text = "Current Stones: " + objectRefernce.OnGensstone.ToString();
                break;
            case "Coppermine":
                infoText.text = "Current Coppers: " + objectRefernce.OnGenscopper.ToString();
                break;
            case "Ironmine":
                infoText.text = "Current Irons: " + objectRefernce.OnGensiron.ToString();
                break;
            case "Goldmine":
                infoText.text = "Current Golds: " + objectRefernce.OnGensgold.ToString();
                break;
            case "Thermalplant":
                infoText.text = "Woods Fuel: " + objectRefernce.Building.DrainResource + "/S" 
                    + "\n" + "Energy: " + objectRefernce.Building.DeductENG;
                break;
            case (_):
                infoText.text = "Energy: " + objectRefernce.Building.DeductENG;
                break;
        }
    }

    private void OnMouseExit()
    {
        if (MouseHoverDestroyBtn.IsHovering)
        {
            return;
        }
        _mouseExit = true;
    }
}
