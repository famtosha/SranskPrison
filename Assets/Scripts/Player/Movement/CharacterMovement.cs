using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    public Vector2 sizeMultiply = Vector2.one;
    public LayerMask floor;
    public bool canMove = true;
    public MoveBehavior walk;
    public MoveBehavior climb;
    public MoveBehavior currentMoveBehavior
    {
        get => _currentMoveBehavior;
        set
        {
            _currentMoveBehavior?.Exit();
            _currentMoveBehavior = value;
            _currentMoveBehavior?.Enter();
        }
    }

    public Ladder nearLadder;

    private bool isActive = true;
    private Rigidbody2D rb;
    public float defgravity;
    private BoxCollider2D boxCollider;
    private MoveBehavior _currentMoveBehavior;
    private void Awake()
    {
        walk = Instantiate(walk);
        climb = Instantiate(climb);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        defgravity = rb.gravityScale;

        walk.characterMovement = this;
        climb.characterMovement = this;
        currentMoveBehavior = walk;
    }
    public bool isOnLadder => currentMoveBehavior is Climb;
    public Vector2 velocity { get => rb.velocity; set => rb.velocity = value; }
    public float gravityScale { get => rb.gravityScale; set => rb.gravityScale = value; }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void MovePosition(Vector2 position)
    {
        rb.MovePosition(position);
    }

    private void FixedUpdate()
    {
        if (isActive) TryLeaveLadder();
        if (!isOnLadder && nearLadder) TryGrabLadder();
        if (isOnLadder && nearLadder == null) LeaveLadder();
        if (isActive && Input.GetKeyDown(InputSettings.current.jump)) currentMoveBehavior.Jump();
        Move();
    }

    public void Move()
    {
        if (isActive)
        {
            currentMoveBehavior.ActiveMove(InputUtils.GetMoveInput());
        }
        else
        {
            currentMoveBehavior.PassiveMove(InputUtils.GetMoveInput());
        }
    }

    public void TouchLadder() => nearLadder = null;
    public void UntouchLadder(Ladder ladder) => nearLadder = ladder;

    public void DisableMovement() => isActive = false;
    public void EnableMovement() => isActive = true;

    public void TryGrabLadder()
    {
        var inputY = Input.GetAxis("Vertical");
        if (inputY > 0 || (inputY < 0 && !IsGounded())) currentMoveBehavior = climb;
    }

    public void TryLeaveLadder()
    {
        if (Input.GetAxis("Vertical") < 0 && IsGounded()) currentMoveBehavior = walk;
    }

    public void LeaveLadder() => currentMoveBehavior = walk;

    public void UpdateLookDirection(float xAxis)
    {
        if (xAxis > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (xAxis < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public bool IsGounded()
    {
        Vector2 center = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale).MultiplyPoint(boxCollider.offset);
        var size = boxCollider.size * transform.localScale;
        size.x /= 1.1f;
        return Physics2D.BoxCast(center, size, 0f, -transform.up, 0.1f, floor);
    }

    //private void OnDrawGizmos()
    //{
    //    boxCollider = GetComponent<BoxCollider2D>();
    //    Vector2 center = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale).MultiplyPoint(boxCollider.offset);
    //    var size = boxCollider.size * transform.localScale;
    //    size.x /= 1.1f;
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(center - new Vector2(0, 0.1f), size);
    //}
}