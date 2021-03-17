using UnityEngine;

public abstract class MoveBehavior : ScriptableObject
{
    public CharacterMovement characterMovement { get; set; }
    public abstract void Jump();
    public abstract void ActiveMove(Vector2 moveDirection);
    public abstract void PassiveMove(Vector2 moveDirection);
    public abstract void Enter();
    public abstract void Exit();
}
