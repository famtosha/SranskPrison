using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float stopSpeed;
    public float speedLimit;
    public float jumpForce;
    public float moveSpeedMultiply = 1;

    public float charHeight = 1;

    public LayerMask floor;
    public bool canMove = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);                           //get input
        UpdateLookDirection(moveDirection.x);                                                          //rotate char into move direction

        moveDirection = transform.TransformDirection(moveDirection);
        Vector2 moveVector = transform.right * moveDirection * moveSpeed;
        if (IsGounded()) moveVector *= moveSpeedMultiply;
        rb.AddForce(moveVector);

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speedLimit, speedLimit), rb.velocity.y); // clamp X velocity

        if (moveDirection.x == 0f) Stop();                                                             // stop char if dont get input
    }

    private void Stop()
    {
        var stopVelocity = new Vector2(rb.velocity.x, 0);

        stopVelocity *= -1;
        stopVelocity /= 2;
        stopVelocity *= stopSpeed;

        rb.AddForce(stopVelocity);
    }

    public void UpdateLookDirection(float xAxis)
    {
        if (xAxis > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (xAxis < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public bool IsGounded()
    {
        bool result = Physics2D.Raycast(transform.position, -transform.up, charHeight, floor);
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, charHeight, 0));
    }

    public void Jump()
    {
        if (IsGounded())
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
}
