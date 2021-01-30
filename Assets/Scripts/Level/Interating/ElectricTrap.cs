using UnityEngine;

public class ElectricTrap : Trap
{
    public CoolDown activeTime = new CoolDown(3);
    public CoolDown unactiveTime = new CoolDown(5);

    private void Update()
    {
        UpdateTimers();
    }

    private void UpdateTimers()
    {
        if (isActive)
        {
            activeTime.UpdateTimer(Time.deltaTime);
            if (activeTime.isReady)
            {
                isActive = false;
                activeTime.Reset();
            }
        }
        else
        {
            unactiveTime.UpdateTimer(Time.deltaTime);
            if (unactiveTime.isReady)
            {
                isActive = true;
                unactiveTime.Reset();
            }
        }

    }
}