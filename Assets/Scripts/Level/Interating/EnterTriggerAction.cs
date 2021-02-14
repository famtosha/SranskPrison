using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class EnterTriggerAction : MonoBehaviour
{
    public UnityEvent triggerEnter;
    public bool singleUse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEnter.Invoke();
        if (singleUse) gameObject.SetActive(false);
    }
}
