using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    public Item item = new Item();
    public Sprite sprite;

    private void Awake()
    {
        item.itemSprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.gameObject.GetComponent<Character>();
        if(character != null)
        {
            character.PickupItem(this);
        }
    }

    //on pickup
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
