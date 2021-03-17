using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuardMoveBehavior))]
public class Guard : MonoBehaviour, IDamagable
{
    public GameObject itemDrop;
    public Health health = new Health(0, 4, 4);

    protected bool canMove = true;
    protected GuardMoveBehavior movement;

    private void Awake()
    {
        health.Death += Death;
        movement = GetComponent<GuardMoveBehavior>();
    }

    protected virtual void Update()
    {
        movement.Move();
        if (movement.CanSeePlayer()) Attack();
    }

    public virtual void Attack()
    {

    }

    public void DropItem()
    {
        if (itemDrop == null) return;
        itemDrop.SetActive(true);
        itemDrop.transform.position = gameObject.transform.position;
        itemDrop.transform.SetParent(null);
    }

    public void DealDamage(int damage)
    {
        health.health -= damage;
    }

    public void Death()
    {
        DropItem();
        Destroy(gameObject);
    }
}