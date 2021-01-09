using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject playerVisual;
    public float moveSpeed;
    public LayerMask floor;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        var positionOffset = (moveDirection * moveSpeed) + (Physics2D.gravity * rb.gravityScale);
        rb.MovePosition(rb.position + positionOffset * Time.deltaTime);
        UpdateLookDirection(moveDirection.x);
    }

    public void UpdateLookDirection(float xAxis)
    {
        if (xAxis > 0) playerVisual.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (xAxis < 0) playerVisual.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public bool IsGounded => Physics2D.Raycast(transform.position, -transform.up, 1, floor);

    public void Jump()
    {
        print(IsGounded);
        if (IsGounded)
        {
            rb.AddForce(transform.up * 5000);
        }
    }
}
