public class GuardChaseState : GuardBaseState
{
    public override void StateUpdate(GuardStateMachine stateMachine, Guard guard)
    {
        if (guard.CanSeePlayer())
        {
            guard.Attack();
            guard.Move();
        }
        else
        {
            stateMachine.ChangeState(stateMachine.seachState);
        }
    }
}
