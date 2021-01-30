using System.Collections;
using UnityEngine;

public class TrapDisactivator : MonoBehaviour, IInteraction
{
    public float CloseTime = 5;
    public Trap trap;
    public OpenRequire openType => OpenRequire.Closed;

    public void HideInfo() { }
    public void ShowInfo() { }

    public void UseByCharacter(UseAction use, out bool isUsed) { isUsed = false; }

    public void UseByAnotherObject()
    {
        StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        trap.isActive = false;
        yield return new WaitForSeconds(CloseTime);
        trap.isActive = true;
    }
}