using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float XSensitivity;
    public float YSensitivity;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        //This section locks the cursor to the middle of the screen and makes it invisible

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Input.GetKeyDown("m"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
             
        
    }

    void Update()
    {
        //This section is for getting the mouse input

        float mouseX = Input.GetAxisRaw("Mouse X")* Time.deltaTime * XSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y")* Time.deltaTime * YSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        //Stops mouse at the top and bottom of the screen

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //This section rotates player and camera

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }
}
