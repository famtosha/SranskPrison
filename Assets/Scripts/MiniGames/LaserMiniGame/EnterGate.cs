using System.Linq;
using UnityEngine;

public class EnterGate : MonoBehaviour, ILaserSource
{
    public LayerMask minigameLayer;
    public LaserDrawer laserDrawer;

    private void Update()
    {
        CreateLaser();
    }

    private bool CreateLaser(Vector2 source, Vector2 direction, out RaycastHit2D hit)
    {
        var hits = Physics2D.RaycastAll(source, direction, minigameLayer).ToList();
        hits = hits.Where(x => x.collider.gameObject != gameObject).ToList();
        hit = hits[0];
        return hits.Count > 0;
    }

    public void CreateLaser()
    {
        if (CreateLaser(transform.position, transform.right, out var hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out ILaserReciver reciver))
            {
                reciver.ReciveLaser(hit.point);
            }
            laserDrawer.DrawLaser(transform.position, hit.point);
        }
    }
}