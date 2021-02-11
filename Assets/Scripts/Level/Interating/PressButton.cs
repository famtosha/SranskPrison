using UnityEngine;

public class PressButton : Sensor
{
    public Animator buttonAnimator;

    protected override void Down()
    {
        base.Down();
        buttonAnimator.SetTrigger("Down");
    }

    protected override void Up()
    {
        base.Up();
        buttonAnimator.SetTrigger("Up");
    }
}
