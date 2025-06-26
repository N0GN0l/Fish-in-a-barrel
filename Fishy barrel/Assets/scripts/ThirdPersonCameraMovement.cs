using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraMovement : MonoBehaviour
{
    public float xMouseSensitivity = 100f;
    public float yMouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xMouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * yMouseSensitivity * Time.deltaTime;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
        yRotation = Mathf.Clamp(yRotation, -45f, 45f);

        //control rotation around y axis (Look up and down)
        yRotation += mouseX;

        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.position = 

    }
}
