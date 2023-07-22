using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollideObject : MonoBehaviour
{
    public static bool CollideObject;

    private void Awake()
    {
        CollideObject = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag) == gameObject.CompareTag(tag))
        {
            CollideObject = true;
        }
        else
        {
            CollideObject = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CollideObject = false;
    }
}
