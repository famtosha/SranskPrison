using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private GameObject selectIcon = null;
    protected Move move;
    private bool isActive = false;

    public void Awake()
    {
        move = GetComponent<Move>();
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