using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : Trap
{

    public override void Trigger()
    {
        myAnimator.SetTrigger("TrapTriggered");
    }
}
