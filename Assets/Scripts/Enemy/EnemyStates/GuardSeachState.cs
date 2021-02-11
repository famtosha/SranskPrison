public class GuardSeachState : GuardBaseState
{
    public override void StateUpdate(GuardStateMachine stateMachine, Guard guard)
    {
        if (guard.CanSeePlayer())
        {
            stateMachine.ChangeState(stateMachine.chaseState);
        }
        else
        {
            guard.Move();
        }
    }
}
