using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{/*
   //Camera Positioning
   [Header("Camera Positioning")]
   public Vector2 cameraoffset = new Vector2(10f, 14f);
   public float lookatoffset = 2f;

   //Move Controls
   [Header("Move Controls")]
   public float inoutSpeed = 5f;
   public float lateralSpeed = 5f;
   
   //Move Bounds
   [Header("Move Bounds")]
   public Vector2 minBounds, maxBounds;

   Vector3 frameMove;
   Camera cam;

    
    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        cam.transform.localPosition = new Vector3(0f, Mathf.Abs(cameraoffset.y), -Mathf.Abs(cameraoffset.x));
        cam.transform.LookAt(transform.position + Vector3.up * lookatoffset);   
    }

    // Update is called once per frame
    private void OnEnable()
    {
        KeyboardInputManager.OnmoveInput += UpdateFrameMove;
    }

    private void UpdateFrameMove (Vector3 moveVector)
    {
        frameMove += moveVector;
    }

    private void LateUpdate()
    {
        if(frameMove != Vector3.zero)
        {
            Vector3 speedModFramemove = new Vector3(frameMove.x * lateralSpeed, frameMove.y, frameMove.z * inoutSpeed);
            transform.position += transform.TransformDirection(speedModFramemove) * Time.deltaTime;
            LockPositionInBounds();
            frameMove = Vector3.zero;
        }
    }

    private void LockPositionInBounds()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),transform.position.y,
            Mathf.Clamp(transform.position.z, minBounds.y, maxBounds.y)
        );
    }*/
}
