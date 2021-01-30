using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    public bool isAvailable = true;
    public virtual int playerID { get; }
    public UseAction useAction => new UseAction(isHacker, CharacterSelector.instance.playersInventory.inventory[playerID]);
    public Health health = new Health(0, 4, 4);

    protected virtual bool isHacker => false;
    protected CharacterMovement move;
    protected Interacting interacting;

    [SerializeField] private GameObject selectIcon = null;
    private bool isActive = false;

    public void Awake()
    {
        move = GetComponent<CharacterMovement>();
        interacting = GetComponent<Interacting>();
    }

    public void PickupItem(PickupableItem item)
    {
        var inventory = CharacterSelector.instance.playersInventory;
        if (!inventory.hasItem(playerID))
        {
            if (inventory.AddItemToInventory(playerID, item.item))
            {
                item.DestroyItem();
            }
        }
    }

    public void RemoveItem()
    {
        CharacterSelector.instance.playersInventory.DestoryItem(playerID);
    }

    public void Trade(int playerID)
    {
        if (playerID != this.playerID)
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

    protected void ChangState(bool state)
    {
        selectIcon.SetActive(state);
        move.enabled = state;
        interacting.enabled = state;
        isActive = state;
    }

    public virtual void Heal(int amount)
    {
        health.health += amount;
    }

    public virtual void DealDamage(int hearts)
    {
        health.health -= hearts;
    }
}