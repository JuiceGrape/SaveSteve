using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : Trap
{
    [SerializeField]
    protected Collider2D deathzone;

    public void ActivateDeathzone()
    {
        deathzone.enabled = true;
    }

    public override void FinishedAttacking()
    {
        base.FinishedAttacking();
        deathzone.enabled = false;
    }

    protected override void disableTrap()
    {
        deathzone.enabled = false;
        base.disableTrap();
    }

}
