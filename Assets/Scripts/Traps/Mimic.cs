using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : Trap
{
    public override void Trigger(GameObject collisionObject)
    {
        base.Trigger(collisionObject);
        if (collisionObject.GetComponent<Adventurer>().CanDodge(this))
            return;
        collisionObject.GetComponent<Adventurer>().Die();
        FinishedAttacking();
    }
}
