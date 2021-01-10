using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject selectIcon = null;
    protected Move move;
    private bool isActive = false;
    public virtual int playerID { get; }

    public void Awake()
    {
        move = GetComponent<Move>();
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
        isActive = state;
    }
}