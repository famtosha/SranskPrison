using UnityEngine;

public class EnterGate : MonoBehaviour, ILaserSource
{
    public LayerMask minigameLayer;
    public LaserDrawer laserDrawer;

    private void Update()
    {
        CreateLaser();
    }

    private bool CreateLaser(Vector3 source, Vector3 direction, out RaycastHit hit)
    {
        return Physics.Raycast(source, direction, out hit, 100, minigameLayer);
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