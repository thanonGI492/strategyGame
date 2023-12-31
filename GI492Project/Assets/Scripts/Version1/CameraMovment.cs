using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    private Vector3 CameraPosition;

    [Header("Camera Setting")]
    public float CameraSpeed;
    public int rapid;

    [Header("Move Bounds")]
    public Vector2 minBounds, maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.y += CameraSpeed / rapid;
        }

        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.y -= CameraSpeed / rapid;
        }

        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.x -= CameraSpeed / rapid;
        }

        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += CameraSpeed / rapid;
        }

        this.transform.position = CameraPosition;
        LockPositionInBounds();
    }

    private void LockPositionInBounds()
    {
        transform.position = new Vector4
        (
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            transform.position.z
            
        );
    }
}
