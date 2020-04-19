using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : Trap
{
    [SerializeField]
    private float timeTrapIsOpen = 0;

    public List<Adventurer> adventurers = new List<Adventurer>();

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.GetComponent<Adventurer>())
        {
            adventurers.Add(collision.GetComponent<Adventurer>());
            if (isActivated)
            {
                foreach(Adventurer adventurer in adventurers)
                {
                    adventurer.FallInPit(this.transform.position.x);
                }
                adventurers.Clear();
            }
                
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>())
        {
            adventurers.Remove(collision.GetComponent<Adventurer>());
        }
    }

    private IEnumerator TrapOpenTime()
    {
        yield return new WaitForSeconds(timeTrapIsOpen);
        base.FinishedAttacking();
    }
}
   