using System;
using UnityEngine;

public class GuardStateMachine
{
    public IGuardState currentState = new GuardSeachState();
    public Guard guard;

    public IGuardState eatState = new GuardEatState();
    public IGuardState seachState = new GuardSeachState();
    public IGuardState chaseState = new GuardChaseState();

    public void ChangeState(IGuardState newState)
    {
        currentState?.ExitState(this, guard);
        currentState = newState;
        newState?.EnterState(this, guard);
    }

    public void StateUpdate()
    {
        currentState.StateUpdate(this, guard);
    }

    public GuardStateMachine(Guard guard)
    {
        this.guard = guard;
    }
}
