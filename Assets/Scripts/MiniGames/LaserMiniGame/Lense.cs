using UnityEngine;
using System.Linq;

public class Lense : MonoBehaviour, ILaserReciver
{
    public LayerMask minigameLayer;
    public LaserDrawer laserDrawer;

    private bool wasRecivedLastFrame = false;

    public void ReciveLaser(Vector3 hitPoint)
    {
        wasRecivedLastFrame = true;
        if (CreateLaser(transform.position, -GetLaserDirection(hitPoint), out var hit))
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

    private bool CreateLaser(Vector2 source, Vector2 direction, out RaycastHit2D hit)
    {
        var hits = Physics2D.RaycastAll(source, direction, minigameLayer).ToList();
        hits = hits.Where(x => x.collider.gameObject != gameObject).ToList();
        hit = hits[0];
        return hits.Count > 0;
    }

    private Vector3 GetLaserDirection(Vector3 hit)
    {
        return hit - transform.position;
    }
}