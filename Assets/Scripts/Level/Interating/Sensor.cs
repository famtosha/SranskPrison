using UnityEngine;
using System;

public class Sensor : MonoBehaviour
{
    private int playerInTrigger = 0;
    private bool isOpened = false;

    public bool requireAllChars = false;
    public GameObject[] doors;

    private bool IsCharacter(Collider2D collider)
    {
        return collider.gameObject.GetComponent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (IsCharacter(collision))
        {
            playerInTrigger += 1;
            CharcatersNearChanged();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsCharacter(collision))
        {
            playerInTrigger -= 1;
            CharcatersNearChanged();
        }
    }

    //smell shit
    private void CharcatersNearChanged()
    {
        bool isNowOpened;
        if (requireAllChars)
        {
            isNowOpened = playerInTrigger > 3;
        }
        else
        {
            isNowOpened = playerInTrigger > 0;
        }
        if (isNowOpened != isOpened) ChangeDoorState();
        isOpened = isNowOpened;
    }

    private void ChangeDoorState()
    {
        if (doors?.Length > 0)
        {
            foreach (var door in doors)
            {
                door.GetComponent<IInteraction>().UseByAnotherObject();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (doors?.Length < 1) return;
        foreach (var door in doors)
        {
            if (door != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, door.transform.position);
            }
        }
    }
}