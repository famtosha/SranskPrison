using UnityEngine;
using UnityEngine.EventSystems;

public class LenseRailUI : MonoBehaviour, IDragHandler
{
    public LayerMask lenseRailLayer;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var ray = mainCamera.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, lenseRailLayer))
        {
            if (hit.collider.gameObject.TryGetComponent(out LenseRail rail))
            {
                rail.SetPosition(hit.point);
            }

        }
    }
}
