using UnityEngine;
using UnityEngine.EventSystems;

public class LenseRail : MonoBehaviour
{
    public Transform railUpBound;
    public Transform railDownBound;

    public void SetPosition(Vector3 worldPoint)
    {
        float y = Mathf.Clamp(worldPoint.y, railDownBound.position.y, railUpBound.position.y);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(railUpBound.position, railDownBound.position);
        Gizmos.DrawWireCube(railUpBound.position, Vector3.one);
        Gizmos.DrawWireCube(railDownBound.position, Vector3.one);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"Dragged:{eventData.position}");
    }
}
