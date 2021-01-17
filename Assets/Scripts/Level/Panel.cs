using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour, IInteraction
{
    private bool isActive = false;
    public GameObject Info;
    public List<GameObject> doors = new List<GameObject>();

    public virtual OpenRequire openType => OpenRequire.Nothing;

    public void HideInfo() => Info.SetActive(false);
    public void ShowInfo() => Info.SetActive(true);

    protected virtual bool CanUse()
    {
        return !isActive;
    }

    private void OnDrawGizmos()
    {
        if (doors?.Count < 1) return;
        foreach (var door in doors)
        {       
            if(door != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, door.transform.position);           
            }
        }
    }

    protected void Use()
    {
        if (CanUse())
        {
            foreach (GameObject door in doors)
            {
                door.GetComponent<IInteraction>().UseByAnotherObject();
            }
            isActive = !isActive;
        }
    }

    public virtual void UseByCharacter(UseAction use, out bool isUsed)
    {
        Use();
        isUsed = true;
    }

    public virtual void UseByAnotherObject()
    {
        Use();
    }
}