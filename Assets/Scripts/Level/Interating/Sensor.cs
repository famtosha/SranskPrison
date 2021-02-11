using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Sensor : MonoBehaviour
{
    public bool requireAllChars = false;
    public GameObject[] doors;

    private int playerInTrigger = 0;
    protected bool isActivated = false;

    private bool IsCharacter(Collider2D collider)
    {
        return collider.gameObject.GetComponent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (IsCharacter(collision))
        {
            playerInTrigger++;
            CharcatersNearChanged();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsCharacter(collision))
        {
            playerInTrigger--;
            CharcatersNearChanged();
        }
    }

    //smell shit
    private void CharcatersNearChanged()
    {
        bool isNowOpened;
        if (requireAllChars)
        {
            isNowOpened = playerInTrigger >= 3;
        }
        else
        {
            isNowOpened = playerInTrigger > 0;
        }
        if (isNowOpened != isActivated) ChangeDoorState();
        isActivated = isNowOpened;
        if (isActivated)
        {
            Down();
        }
        else
        {
            Up();
        }
    }

    protected virtual void ChangeDoorState()
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
        if (doors != null && doors.Length > 0)
        {
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

    protected virtual void Down()
    {

    }

    protected virtual void Up()
    {

    }
}