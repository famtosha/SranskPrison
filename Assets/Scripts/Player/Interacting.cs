using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    private IInteraction itemNowTouch = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interaction = collision.gameObject.GetComponent<IInteraction>();
        if (interaction != null)
        {
            itemNowTouch = interaction;
            interaction.ShowInfo();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (itemNowTouch != null)
        {
            if (collision.gameObject.GetComponent<IInteraction>() == itemNowTouch)
            {
                itemNowTouch.HideInfo();
                itemNowTouch = null;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemNowTouch != null) itemNowTouch.Use();
    }
}
