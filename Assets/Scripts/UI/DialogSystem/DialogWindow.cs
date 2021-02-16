using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogWindow : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI author;
    public Image authorImage;
    public GameObject root;

    public void SetAuthor(string author)
    {
        this.author.text = author;
    }

    public void SetAuthorImage(Sprite sprite)
    {
        authorImage.sprite = sprite;
    }

    public void SetDialoText(string text)
    {
        dialogText.text = text;
    }

    public void AppendDialogText(char text)
    {
        dialogText.text += text;
    }

    public void ResetDialogText()
    {
        dialogText.text = "";
    }

    public void ResetDialogAuthor()
    {
        author.text = "";
    }

    public void ResetDialogAuthorImage()
    {
        authorImage.sprite = null;
    }

    public void OpenDialogWindow()
    {
        root.SetActive(true);
    }

    public void CloseDialogWindow()
    {
        root.SetActive(false);
    }

    public void ResetDialog()
    {
        ResetDialogText();
        ResetDialogAuthor();
        ResetDialogAuthorImage();
    }

    public void Update()
    {
        authorImage.gameObject.transform.Rotate(new Vector3(0, 0, Mathf.Sin(Time.time * 3) / 3));
    }
}
