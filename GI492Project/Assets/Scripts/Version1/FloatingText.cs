using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private Vector3 offSet;

    private void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += offSet;
    }
}
