public class SlimeFatSearchState : GuardSeachState
{
    public override void StateUpdate(GuardStateMachine stateMachine, Guard guard)
    {
        base.StateUpdate(stateMachine, guard);

        if (guard.health < guard.health.max)
        {
            stateMachine.ChangeState(stateMachine.eatState);
        }
    }
}
