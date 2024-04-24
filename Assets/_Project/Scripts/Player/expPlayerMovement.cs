using UnityEngine;

public class expPlayerMovement : MonoBehaviour
{
    [SerializeField] MotionController movementController;

    Vector2 dirInputSmooth;
    Vector2 dirInputTarget;
    Vector2 dirInputSmoothVelocity;
    [SerializeField] float dirInputSmoothTime;
    [SerializeField] private Mode mode;
    [SerializeField] private PlayerPosition playerPosition;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 dirInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        bool isMoving = dirInput != Vector2.zero;
        if (isMoving && mode.mode3D)
        {
            dirInputTarget = dirInput;
        }
        dirInputSmooth = Vector2.SmoothDamp(dirInputSmooth, dirInputTarget, ref dirInputSmoothVelocity, dirInputSmoothTime);

        movementController.Update(isMoving);

        Vector3 moveDirection = Vector3.right * dirInputSmooth.x + Vector3.forward * dirInputSmooth.y;
        Vector3 moveVelocity = moveDirection * (movementController.Speed);
        transform.Translate(moveVelocity * Time.deltaTime);
        //rb.AddForce(moveVelocity);
        

        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        playerPosition.position = transform.position;
    }

    public void ResetPlayerVelocity()
    {
        rb.velocity = Vector3.zero;
    }
}