using UnityEngine;

public class AnimatorWrapper : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    public static readonly int jumpTriggerID = Animator.StringToHash("Jump");
    public static readonly int isWalkingBoolID = Animator.StringToHash("IsWalking");
    public static readonly int enterKickID = Animator.StringToHash("EnterKick");
    public static readonly int kickTriggerID = Animator.StringToHash("Kick");
    public static readonly int exitKickID = Animator.StringToHash("ExitKick");
    public static readonly int enterLadderTriggerID = Animator.StringToHash("EnterLadder");
    public static readonly int exitLadderTriggerID = Animator.StringToHash("ExitLadder");
    public static readonly int isMovingOnLadderBoolID = Animator.StringToHash("IsMovingOnLadder");

    public void SetTrigger(int triggerID)
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator?.SetTrigger(triggerID);
        }
    }

    public void SetBool(int boolID, bool value)
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetBool(boolID, value);
        }
    }
}
