using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : Trap
{

    public override void Trigger(GameObject collisionObject)
    {
        collisionObject.GetComponent<Adventurer>().AttackedByTrap();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>() && isActivated)
        {
            collision.GetComponent<Adventurer>().AttackedByTrap();
        }
        base.OnTriggerEnter2D(collision);
    }
}
