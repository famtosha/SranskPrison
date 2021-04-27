using UnityEngine;

public class LaserDrawer : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefub;
    private GameObject _laserInstance;
    public GameObject laserInstance
    {
        get
        {
            if (_laserInstance == null) _laserInstance = Instantiate(laserPrefub);
            return _laserInstance;
        }
    }

    public void DrawLaser(Vector3 start, Vector3 end)
    {
        laserInstance.SetActive(true);
        Vector3 center = Vector3.Lerp(start, end, 0.5f);
        Vector3 direction = end - start;
        float length = Vector3.Distance(start, end);
        float scale = 1f * length;
        laserInstance.transform.position = center;
        laserInstance.transform.up = direction;
        laserInstance.transform.localScale = new Vector3(0.1f, scale, 0.1f);
    }

    public void HideLaser()
    {
        laserInstance.SetActive(false);
    }
}
