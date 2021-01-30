using UnityEngine;

public class GiveItemInfo : MonoBehaviour
{
    public GameObject giveItemInfo;
    public static GiveItemInfo instance;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        instance = this;
    }

    public void ShowInfo()
    {
        giveItemInfo.SetActive(true);
    }

    public void HideInfo()
    {
        giveItemInfo.SetActive(false);
    }
}