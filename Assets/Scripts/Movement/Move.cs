using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D player;
    public float moveSpeed;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * moveSpeed;
        moveDirection = transform.TransformDirection(moveDirection);
        player.MovePosition(transform.position + moveDirection);
    }
}
