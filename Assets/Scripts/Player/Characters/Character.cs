using System;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Interacting))]
[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour, IDamagable
{
    public bool isAvailable = true;
    public virtual int playerID { get; }
    public UseAction useAction => new UseAction(isHacker, CharacterSelector.instance.playersInventory.inventory[playerID] as Key);
    public Health health = new Health(0, 4, 4);

    protected virtual bool isHacker => false;
    protected CharacterMovement move;
    protected Interacting interacting;

    [SerializeField] private GameObject selectIcon = null;

    public bool isActive = false;

    public void Awake()
    {
        move = GetComponent<CharacterMovement>();
        interacting = GetComponent<Interacting>();
        health.Death += OnDeath;
    }

    public void PickupItem(PickupableItem item)
    {
        var inventory = CharacterSelector.instance.playersInventory;
        if (!inventory.HasItem(playerID))
        {
            if (inventory.AddItem(playerID, item.item))
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
        if (Input.GetKeyDown(InputSettings.current.useItem) && isActive) UseItem();
    }

    protected virtual void ActiveUpdate()
    {

    }

    public virtual void Select() => EnableCharacter();

    public virtual void Deselect() => DisableCharacter();


    protected void DisableCharacter()
    {
        selectIcon.SetActive(false);
        move.DisableMovement();
        interacting.enabled = false;
        isActive = false;
    }

    protected void EnableCharacter()
    {
        selectIcon.SetActive(true);
        move.EnableMovement();
        interacting.enabled = true;
        isActive = true;
    }

    public virtual void Heal(int amount)
    {
        health.health += amount;
    }

    public virtual void DealDamage(int hearts)
    {
        health.health -= hearts;
    }

    public virtual void OnDeath()
    {
        Debug.LogError("player ded x_x");
    }

    public void UseItem()
    {
        var item = CharacterSelector.instance.playersInventory.TakeItem(playerID) as ConsumableItem;
        if (item)
        {
            item.Use(gameObject);
        }
    }
}