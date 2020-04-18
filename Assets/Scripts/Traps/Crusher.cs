using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : Trap
{

    private bool isArmed;
    private bool isActivated;

    [SerializeField]
    private TrapButton myButton = null;
    [SerializeField]
    protected Animator myAnimator;

    protected Collider2D myCollider;
    [SerializeField]
    protected Collider2D deathzone;

    public void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myCollider.isTrigger = true;
        myCollider.enabled = false;
    }

    public void Trigger()
    {
        myAnimator.SetTrigger("TrapTriggered");
    }

    public override void ArmTrap()
    {
        isArmed = true;
        myCollider.enabled = true;
    }

    public void ActivateDeathzone()
    {
        deathzone.enabled = true;
    }

    public void finishedAttacking()
    {
        isArmed = false;
        myButton.activateCooldown();
        myCollider.enabled = false;
        deathzone.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>() && isArmed)
        {
            Trigger();
        }
    }

}
