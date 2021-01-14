using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask floor;
    public bool canMove = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
        UpdateLookDirection(moveDirection.x);
        var positionOffset = (moveDirection * moveSpeed) + (Physics2D.gravity * rb.gravityScale);
        if(canMove) rb.MovePosition(rb.position + positionOffset * Time.deltaTime);
    }

    public void UpdateLookDirection(float xAxis)
    {
        if (xAxis > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (xAxis < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public bool IsGounded => Physics2D.Raycast(transform.position, -transform.up, 1, floor);

    public void Jump()
    {
        if (IsGounded)
        {
            rb.AddForce(transform.up * 5000);
        }
    }
}
