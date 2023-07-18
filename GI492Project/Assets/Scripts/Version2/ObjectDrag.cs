using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    

    //private variable
    private Vector3 _offset;

    private void OnMouseDown(){
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag(){
        Vector2 pos= Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        transform.position = BuildingVersionTwo.Instance.SnapCoodinateToGrid(pos);
    }
}
