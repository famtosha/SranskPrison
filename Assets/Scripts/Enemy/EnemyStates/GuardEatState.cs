using UnityEngine;

public class GuardEatState : GuardBaseState
{
    private CoolDown eatTime = new CoolDown(4);

    public override void EnterState(GuardStateMachine stateMachine, Guard guard)
    {
        eatTime.Reset();
    }

    public override void StateUpdate(GuardStateMachine stateMachine, Guard guard)
    {
        eatTime.UpdateTimer(Time.deltaTime);
        if (eatTime.isReady)
        {
            guard.health++;
            stateMachine.ChangeState(stateMachine.seachState);
        }
    }
}
