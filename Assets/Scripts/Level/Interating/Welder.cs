using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Welder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>()) collision.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>()) collision.gameObject.transform.SetParent(null);
    }
}
