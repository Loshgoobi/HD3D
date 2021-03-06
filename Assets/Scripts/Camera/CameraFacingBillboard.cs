﻿using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    //public Camera m_Camera;
    private Camera m_Camera;

    void Start()
    {
        m_Camera = FindObjectOfType<Camera>();
        Debug.Log("camera name : " + m_Camera.name);
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}