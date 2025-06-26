using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    Camera m_MainCamera;
    public Camera m_CameraTwo;
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        m_CameraTwo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (m_MainCamera.enabled)
            {
                m_CameraTwo.enabled = true;
                m_MainCamera.enabled = false;
            }
            else
            {
                m_MainCamera.enabled = true;
                m_CameraTwo.enabled = false;
            }
        }
    }
}
