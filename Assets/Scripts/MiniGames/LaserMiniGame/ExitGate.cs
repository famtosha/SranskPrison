using UnityEngine;
using UnityEngine.Events;

public class ExitGate : MonoBehaviour, ILaserReciver
{
    public UnityEvent gameEnded;

    public void ReciveLaser(Vector3 hitPoint)
    {
        gameEnded.Invoke();
    }
}