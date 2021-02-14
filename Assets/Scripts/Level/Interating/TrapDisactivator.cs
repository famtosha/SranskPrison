using System.Collections;
using UnityEngine;

public class TrapDisactivator : MonoBehaviour, IInteraction
{
    public float CloseTime = 5;
    public Trap trap;
    public OpenRequire openType => OpenRequire.Closed;

    public void HideInfo() { }
    public void ShowInfo() { }

    public bool UseByCharacter(UseAction use) { return false; }

    public bool UseByAnotherObject()
    {
        StartCoroutine(Open());
        return true;
    }

    private IEnumerator Open()
    {
        trap.isActive = false;
        yield return new WaitForSeconds(CloseTime);
        trap.isActive = true;
    }
}