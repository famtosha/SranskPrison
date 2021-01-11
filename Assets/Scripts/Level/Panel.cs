using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour, IInteraction
{
    private bool isActive = false;
    public GameObject Info;
    public List<GameObject> doors;

    public virtual OpenRequire openType => OpenRequire.Nothing;

    public void HideInfo() => Info.SetActive(false);
    public void ShowInfo() => Info.SetActive(true);

    protected virtual bool CanUse()
    {
        return !isActive;
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

    public virtual void UseByCharacter(UseAction use)
    {
        Use();
    }

    public virtual void UseByAnotherObject()
    {
        Use();
    }
}
