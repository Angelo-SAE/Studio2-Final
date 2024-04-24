using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Mode mode;
    [SerializeField] private PlayerPosition playerPosition;

    private float moveForward;
    private float moveSideways;

    private Rigidbody rb;
    public Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Collect input from the keyboard
        moveForward = Input.GetAxis("Vertical");
        moveSideways = Input.GetAxis("Horizontal");

        SetPlayerPosition();
        
    }

    void FixedUpdate()
    {
        if (mode.mode3D)
        {
            MovePlayer();
        }

    }

    private void SetPlayerPosition()
    {
        playerPosition.position = transform.position;
    }

    private void MovePlayer()
    {
        Vector3 cameraForward = cam.transform.forward;
        Vector3 cameraRight = cam.transform.right;
        cameraForward.y = 0; // Neutralize the y component to keep movement horizontal
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveForward + cameraRight * moveSideways) * moveSpeed;
        Vector3 newPosition = rb.position + movement * Time.deltaTime; // Calculate new position based on current position and movement vector
        rb.MovePosition(newPosition);
    }

    public void ResetPlayerPosition()
    {
        rb.position = Vector3.zero; // Resets the player's position
    }
}
