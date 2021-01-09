using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private GameObject selectIcon = null;
    protected Move move;
    private bool isActive = false;

    public GameObject itemInArm;

    public void Awake()
    {
        move = GetComponent<Move>();
    }

    public void PickupItem(PickupableItem item)
    {
        if (!isActive && itemInArm != null) return;

        item.gameObject.transform.SetParent(gameObject.transform);
        itemInArm = item.gameObject;
        itemInArm.GetComponent<Collider2D>().enabled = false;
    }

    public void DropItem()
    {
        if (itemInArm == null) return;

        itemInArm.GetComponent<Collider2D>().enabled = true;
        itemInArm.gameObject.transform.SetParent(null);
        itemInArm = null;
    }

    private void Update()
    {
        if (isActive) CharacterUpdate();
        if (Input.GetKeyDown(KeyCode.V) && isActive) DropItem();
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