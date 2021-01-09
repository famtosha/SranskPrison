public class CoolDown
{
    public float cd;
    public float cdLeft;

    public bool isReady => cdLeft < 0;
    public void UpdateTimer(float time) => cdLeft -= time;
    public void Reset() => cdLeft = cd;

    public CoolDown(float cd)
    {
        this.cd = cd;
    }
}
