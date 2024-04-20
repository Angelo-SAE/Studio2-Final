using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private FloatObject mouseSensitivity;
    public Transform playerBody;
    private float xRotation = 0f;
    [SerializeField] private Mode mode;

    private void FixedUpdate()
    {
      if(mode.mode3D)
      {
        RotateCamera();
      }
    }

    private void RotateCamera()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.value * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.value * Time.deltaTime;

      xRotation -= mouseY;
      xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
      playerBody.Rotate(Vector3.up * mouseX);
    }
}
