using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        Vector3 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * moveSpeed;
        moveDirection = transform.TransformDirection(moveDirection);
        rb.MovePosition(transform.position + moveDirection);
    }

    public bool IsGounded => true;

    public void Jump()
    {
        if (IsGounded)
        {
            rb.AddForce(transform.up * 500);
        }
    }
}
