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

    Rigidbody rb;
    private bool isGrounded;
    public Camera cam;
    public bool isForcedDown;

    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      CheckForJump();
      SetPlayerPosition();
    }

    void FixedUpdate()
    {
      if(mode.mode3D)
      {
        MovePlayer();
      }
    }

    private void CheckForJump()
    {
      if (Input.GetButtonDown("Jump") && isGrounded && mode.mode3D)
      {
        Jump();
      }
    }

    private void SetPlayerPosition()
    {
      playerPosition.position = transform.position;
    }

    void MovePlayer()
    {
        Vector3 cameraForward = cam.transform.forward;
        Vector3 cameraRight = cam.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();


        float moveForward = Input.GetAxis("Vertical");
        float moveSideways = Input.GetAxis("Horizontal");


        Vector3 movement = (cameraForward * moveForward + cameraRight * moveSideways) * moveSpeed;


        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (rb.velocity.y < -0.1f)
        {
            rb.AddForce(-Vector3.up * jumpFallForce);
            isForcedDown = true;
        }
        else
        {
            isForcedDown = false;

        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
    }


    void OnCollisionEnter(Collision collision) //Reused from old project, will change to better groundCheck system later
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
