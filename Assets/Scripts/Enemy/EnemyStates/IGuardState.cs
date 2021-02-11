using System;

public interface IGuardState
{
    void EnterState(GuardStateMachine stateMachine, Guard guard);
    void ExitState(GuardStateMachine stateMachine, Guard guard);
    void StateUpdate(GuardStateMachine stateMachine, Guard guard);
}
