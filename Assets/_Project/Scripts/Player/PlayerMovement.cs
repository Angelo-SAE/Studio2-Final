using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    [SerializeField] private float jumpFallForce;
    [SerializeField] private Mode mode;
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private Vector3Object playerRotation;

    private float moveForward;
    private float moveSideways;



    Rigidbody rb;

    public Camera cam;
    public bool isForcedDown;

    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        moveForward = Input.GetAxis("Vertical");
        moveSideways = Input.GetAxis("Horizontal");

        /* if (mode.mode3D)
        {
            MovePlayer();
        }*/


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
      playerRotation.value = transform.eulerAngles;
    }

    private void MovePlayer()
    {
        Vector3 cameraForward = cam.transform.forward;
        Vector3 cameraRight = cam.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveForward + cameraRight * moveSideways) * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


    }
    public void ResetPlayerVelocity()
    {
      rb.velocity = Vector3.zero;
    }
}
