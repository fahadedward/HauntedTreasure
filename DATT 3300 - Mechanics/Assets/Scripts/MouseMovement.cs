using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSpeed = 100;
    public Transform player;
    float xRotation = 0;
    void Start()
    {
        // locks the cursor so it doesnt go off the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // we use this instead of .Rotate so we are able to clamp the rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
        
       
    }
}
