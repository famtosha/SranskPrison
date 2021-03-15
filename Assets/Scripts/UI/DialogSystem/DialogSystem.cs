using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem current;

    private Queue<DialogData> dialogQueue = new Queue<DialogData>();
    private DialogWindow dialogWindow;
    private bool isShowingDialog = false;

    private void Start()
    {
        dialogWindow = FindObjectOfType<DialogWindow>();
        current = this;
    }

    public void AddToDialogQueue(DialogData dialog)
    {
        if (dialogQueue.Contains(dialog)) Debug.LogError("2 same dialog in queue, probably dialogue cycle");
        dialogQueue.Enqueue(dialog);
        if (dialog.nextDialog != null) AddToDialogQueue(dialog.nextDialog);
    }

    public void Update()
    {
        if (!isShowingDialog) ProduceNextDioalog();
    }

    public void ProduceNextDioalog()
    {
        if (dialogQueue.Count > 0)
        {
            var nextDialog = new Dialog(dialogQueue.Dequeue());
            StartDialog(nextDialog);
        }
    }

    public void StartDialog(Dialog dialog)
    {
        dialogWindow.OpenDialogWindow();
        dialogWindow.ResetDialog();
        StartCoroutine(ProduceDialog(dialog));
        isShowingDialog = true;
    }

    public IEnumerator ProduceDialog(Dialog dialog)
    {
        dialogWindow.SetAuthor(dialog.data.character.characterName.ToString());
        dialogWindow.SetAuthorImage(dialog.data.image);
        while (dialog.CanRead())
        {
            dialogWindow.AppendDialogText(dialog.GetNextChar());
            yield return new WaitForSeconds(1 / dialog.data.textSpeed);
        }
        yield return new WaitForSeconds(dialog.data.exitTime);
        EndDioalog(dialog);
    }

    public void EndDioalog(Dialog dialog)
    {
        dialogWindow.CloseDialogWindow();
        isShowingDialog = false;
    }
}