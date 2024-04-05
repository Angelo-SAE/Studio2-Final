using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    public Transform playerBody; // Reference to the player body for rotation
    private float xRotation = 0f; // To keep track of camera rotation on the X axis
    [SerializeField] private Mode mode;

    void Update()
    {
      if(mode.mode3D)
      {
        RotateCamera();
      }
    }

    private void RotateCamera()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

      xRotation -= mouseY; // Increment the xRotation based on the mouseY input
      xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the rotation to prevent flipping

      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Apply rotation to the camera
      playerBody.Rotate(Vector3.up * mouseX); // Rotate the player body around the Y axis
    }
}
