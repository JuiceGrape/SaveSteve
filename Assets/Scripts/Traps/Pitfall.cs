using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : Trap
{
    [SerializeField]
    private float timeTrapIsOpen = 0;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.GetComponent<Adventurer>() && isActivated)
        {
            collision.GetComponent<Adventurer>().FallInPit(this.transform.position.x);
        }
    }

    private IEnumerator TrapOpenTime()
    {
        yield return new WaitForSeconds(timeTrapIsOpen);
        base.disableTrap();
    }
}
