using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PickupableItem : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {
            character.PickupItem(this);
        }
    }   

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}