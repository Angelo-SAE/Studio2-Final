using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalMovement : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    private float speedPercent;


    public AnimationCurve
       acceleration = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0)),
       deceleration = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
    [SerializeField] AnimationCurve timeline;


    [SerializeField] private Mode mode;
    [SerializeField] private PlayerPosition playerPosition;

    private Rigidbody rb;
    private Camera playerCamera;

    private float inputH;
    private float inputV;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
    }

    private void Update()
    {
        SetPlayerPosition();
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
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
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        right.Normalize();


        Vector3 movementDirection = (forward * inputV + right * inputH).normalized;


        float accel = acceleration.Evaluate(rb.velocity.magnitude);


        rb.AddForce(movementDirection * accel * maxSpeed, ForceMode.Acceleration);

    }

    [System.Serializable]
    public struct MotionController
    {
        [SerializeField] ExperimentalMovement curve;

        [SerializeField] float speedMax;
        float speedPercent;
        public float Speed => speedMax * speedPercent;

        float time;
        bool wasMoving;
        public void Update(bool isMoving)
        {
            AnimationCurve currentCurve = isMoving
                ? curve.acceleration
                : curve.deceleration;

            // Switch Curves
            if (isMoving != wasMoving)
            {
                time = currentCurve.GetTime(speedPercent);
            }
            time = Mathf.Clamp(time + Time.deltaTime, 0, currentCurve.GetDuration());
            speedPercent = currentCurve.Evaluate(time);

            wasMoving = isMoving;
        }
    }
}
