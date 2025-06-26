using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float xMouseSensitivity = 100f;
    public float yMouseSensitivity = 100f;
 
    float xRotation = 0f;
    float YRotation = 0f;
 
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X") * xMouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * yMouseSensitivity * 2 * Time.deltaTime;
 
       //control rotation around x axis (Look up and down)
       xRotation -= mouseY;
 
       //we clamp the rotation so we cant Over-rotate (like in real life)
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);
 
       //control rotation around y axis (Look up and down)
       YRotation += mouseX;
 
       //applying both rotations
       transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
 
    }
}
