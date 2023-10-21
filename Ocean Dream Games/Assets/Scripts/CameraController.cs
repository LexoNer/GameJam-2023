using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mainCamera.transform.position = transform.position + new Vector3(Time.deltaTime, 0, 0);
        mainCamera.transform.LookAt(transform.position);
    }
}
