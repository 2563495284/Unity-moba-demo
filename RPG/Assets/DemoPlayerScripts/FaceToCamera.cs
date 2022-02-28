using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    public Camera cameraToLookAt;

    private void Start()
    {
        cameraToLookAt=Camera.main;
    }

    private void Update()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position-v);
        transform.Rotate(0,180,0);
    }
}
