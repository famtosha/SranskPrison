using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private GameObject selectIcon = null;
    protected Move move;

    public virtual void SpectialUse()
    {

    }

    public void Awake()
    {
        move = GetComponent<Move>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) SpectialUse();
    }

    public virtual void Select()
    {
        selectIcon.SetActive(true);
        move.enabled = true;
    }
    public virtual void Deselect()
    {
        selectIcon.SetActive(false);
        move.enabled = false;
    }
}
