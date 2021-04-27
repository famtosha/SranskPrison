using UnityEngine;

public class Lense : MonoBehaviour, ILaserReciver
{
    public LayerMask minigameLayer;
    public LaserDrawer laserDrawer;

    private bool wasRecivedLastFrame = false;

    public void ReciveLaser(Vector3 hitPoint)
    {
        wasRecivedLastFrame = true;
        if (CreateLaser(transform.position, GetLaserDirection(hitPoint), out var hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out ILaserReciver reciver))
            {
                reciver.ReciveLaser(hit.point);
            }
            laserDrawer.DrawLaser(transform.position, hit.point);
        }
        else
        {
            laserDrawer.HideLaser();
        }
    }

    private void Update()
    {
        if (!wasRecivedLastFrame)
        {
            laserDrawer.HideLaser();
        }
        wasRecivedLastFrame = false;
    }

    private bool CreateLaser(Vector3 source, Vector3 direction, out RaycastHit hit)
    {
        return Physics.Raycast(source, -direction, out hit, 100, minigameLayer);
    }

    private Vector3 GetLaserDirection(Vector3 hit)
    {
        return hit - transform.position;
    }
}