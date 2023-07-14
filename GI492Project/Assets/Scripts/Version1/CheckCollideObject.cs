using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollideObject : MonoBehaviour
{
    public static bool CollideObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BuildingSystem>())
        {
            CollideObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CollideObject = false;
    }

    private void Update()
    {
        Debug.Log(CollideObject);
    }
}
