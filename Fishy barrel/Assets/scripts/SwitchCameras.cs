using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera m_MainCamera;
    public Camera m_CameraTwo;
    private int cameraMode = 0;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (cameraMode == 0)
            {
                cameraMode = 1;
            }
            else if (cameraMode == 1)
            {
                cameraMode = 0;
            }
            StartCoroutine(Swap());
        }
    }
    IEnumerator Swap()
    { 
        yield return new WaitForSeconds(0.01f);
        if (cameraMode == 0)
        {
            m_CameraTwo.enabled = true;
            m_MainCamera.enabled = false;
        }
        else if (cameraMode == 1)
        {
            m_MainCamera.enabled = true;
            m_CameraTwo.enabled = false;
        }
    }
}
