using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float stopSpeed;
    public float speedLimit;
    public float jumpForce;
    public Vector2 moveSpeedMultiply = Vector2.one;
    public Vector2 sizeMultiply = Vector2.one;
    public float ladderGrapSpeed = 1;
    public LayerMask floor;
    public bool canMove = true;

    private bool isActive = true;
    private Rigidbody2D rb;
    private bool isOnLadder = false;
    private float _defgravity;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        _defgravity = rb.gravityScale;
    }

    private void FixedUpdate()
    {
        if (isActive) Move();
        else Stop();
        if (isOnLadder) MoveOnLadder();
    }

    public void DisableMovement()
    {
        isActive = false;
    }

    public void EnableMovement()
    {
        isActive = true;
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);                           //get input
        UpdateLookDirection(moveDirection.x);                                                          //rotate char into move direction

        moveDirection = transform.TransformDirection(moveDirection);
        Vector2 moveVector = transform.right * moveDirection * moveSpeed;
        if (IsGounded()) moveVector *= moveSpeedMultiply.x;
        rb.AddForce(moveVector);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speedLimit, speedLimit), rb.velocity.y); // clamp X velocity
        if (moveDirection.x == 0f) Stop();                                                             // stop char if dont get input
    }

    private void Stop()
    {
        if (IsGounded())
        {
            var stopVelocity = new Vector2(rb.velocity.x, 0);

            stopVelocity *= -1;
            stopVelocity /= 2;
            stopVelocity *= stopSpeed;

            rb.AddForce(stopVelocity);
        }
    }

    public void UpdateLookDirection(float xAxis)
    {
        if (xAxis > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (xAxis < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public bool IsGounded()
    {
        var center = transform.position.ToVector2() + boxCollider.offset;
        var size = boxCollider.size * transform.localScale;
        bool result = Physics2D.BoxCast(center, size, 0f, -transform.up, 0.1f, floor);

        return result;
    }

    //private void OnDrawGizmos()
    //{
    //    boxCollider = GetComponent<BoxCollider2D>();
    //    var center = transform.position.ToVector2() + boxCollider.offset;
    //    var size = boxCollider.size * transform.localScale;
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(center, size);
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(center + new Vector2(0, -0.1f), size);
    //}

    private void MoveOnLadder() //rewrite in furute
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 grabDirection = transform.up * verticalInput * ladderGrapSpeed;

        rb.MovePosition((Vector2)transform.position + grabDirection);
    }

    public void ExitLadder()
    {
        rb.gravityScale = _defgravity;
        isOnLadder = false;
    }

    public void EnterLadder()
    {
        rb.gravityScale = 0;
        isOnLadder = true;
    }

    public void Jump()
    {
        if (IsGounded())
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
}