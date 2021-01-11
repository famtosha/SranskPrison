using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject selectIcon = null;
    protected virtual bool isHacker => false;
    public UseAction useAction => new UseAction(isHacker, CharacterSelector.instance.playersInventory.inventory[playerID]);
    protected Move move;
    protected Interacting interacting;
    private bool isActive = false;
    public virtual int playerID { get; }

    public void Awake()
    {
        move = GetComponent<Move>();
        interacting = GetComponent<Interacting>();
    }

    public virtual void DealDamage(float damage)
    {
        Debug.LogError("player ded x_x");
    }

    public void PickupItem(PickupableItem item)
    {
        if (!CharacterSelector.instance.playersInventory.hasItem(playerID))
        {
            if(CharacterSelector.instance.playersInventory.AddItemToInventory(playerID, item.item))
            {
                item.DestroyItem();
            }
        }
    }

    public void Trade(int playerID)
    {
        if(playerID != this.playerID)
        {
            CharacterSelector.instance.playersInventory.SwitchItems(playerID, this.playerID);
        }
    }

    protected virtual void Update()
    {
        if (isActive) ActiveUpdate();
    }

    protected virtual void ActiveUpdate()
    {

    }

    public virtual void Select() => ChangState(true);

    public virtual void Deselect() => ChangState(false);

    private void ChangState(bool state)
    {
        selectIcon.SetActive(state);
        move.enabled = state;
        interacting.enabled = state;
        isActive = state;
    }
}