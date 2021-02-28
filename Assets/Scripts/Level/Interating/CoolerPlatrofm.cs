using UnityEngine;

public class CoolerPlatrofm : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;

    public float speed;

    private void Update()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(speed * Time.time, 1));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startPosition, endPosition);
    }
}
