using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour, IInteraction
{
    private bool isActive = false;
    public GameObject Info;
    public List<GameObject> doors;

    public void HideInfo() => Info.SetActive(false);
    public void ShowInfo() => Info.SetActive(true);

    public void Use()
    {
        if (!isActive)
        {
            foreach (GameObject door in doors)
            {
                door.GetComponent<IInteraction>().Use();
            }
            isActive = !isActive;
        }
    }
}
