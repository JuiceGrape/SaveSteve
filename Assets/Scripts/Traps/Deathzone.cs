using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    private Crusher myTrap;

    private void Start()
    {
        myTrap = GetComponentInParent<Crusher>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>())
        {
            collision.GetComponent<Adventurer>().AttackedByTrap();
        }
        myTrap.FinishedAttacking();
    }
}
