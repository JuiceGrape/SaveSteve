using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : Trap
{

    public override void Trigger(GameObject collisionObject)
    {
        base.Trigger(null);
        collisionObject.GetComponent<Adventurer>().Die();
    }

    public override void ArmTrap()
    {
        myAnimator.SetTrigger("TrapArmed");
        base.ArmTrap();
    }
}
