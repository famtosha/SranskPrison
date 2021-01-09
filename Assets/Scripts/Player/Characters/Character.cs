using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject selectIcon = null;
    protected Move move;
    private bool isActive = false;
    public virtual int playerID { get; }

    public void Awake()
    {
        move = GetComponent<Move>();
    }

    public void PickupItem(PickupableItem item)
    {
        if (CharacterSelector.instance.playersInventory.hasItem(playerID))
        {
            if(CharacterSelector.instance.playersInventory.AddItemToInventory(playerID, item.item))
            {
                Destroy(item);
            }
        }
    }

    private void Update()
    {
        if (isActive) CharacterUpdate();
    }

    public virtual void CharacterUpdate()
    {

    }

    public virtual void Select() => ChangState(true);

    public virtual void Deselect() => ChangState(false);

    private void ChangState(bool state)
    {
        selectIcon.SetActive(state);
        move.enabled = state;
        isActive = state;
    }
}