using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotate : MonoBehaviour
{
    public float rotateSpeed = 50f;
    float xRotation = 0f;
    float yRotation = 0f;

    private bool isCursorLocked;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        if(Input.GetKeyDown(KeyCode.E))
        {
            isCursorLocked = !isCursorLocked;
            if(isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
               Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
