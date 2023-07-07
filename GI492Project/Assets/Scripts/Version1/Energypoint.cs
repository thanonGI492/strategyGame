using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energypoint : MonoBehaviour
{
     public int energypoint;
     public TextMeshProUGUI energyUI;

    Collector collector;
    [SerializeField] GameObject energy;
    // Start is called before the first frame update
    void Awake()
    {
        collector = energy.GetComponent<Collector>();
    }

    // Update is called once per frame
    void Update()
    {
        
        energyUI.text = energypoint.ToString();
        collector.CurRegen = energypoint;
        
    }
}
