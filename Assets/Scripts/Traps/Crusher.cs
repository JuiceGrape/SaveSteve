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

    public float FailTime = 5.0f;

    public void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myCollider.isTrigger = true;
        myCollider.enabled = false;
    }

    public void Trigger()
    {
        isActivated = true;
        myAnimator.SetTrigger("TrapTriggered");
    }

    public override void ArmTrap()
    {
        isArmed = true;
        myCollider.enabled = true;
        if (FailTime > 0)
            StartCoroutine(FailAfter(FailTime));
    }

    public void ActivateDeathzone()
    {
        deathzone.enabled = true;
    }

    public void FinishedAttacking()
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

    IEnumerator FailAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (isArmed && !isActivated)
        {
            isArmed = false;
            myCollider.enabled = false;
            deathzone.enabled = false;
            myButton.ResetButton();
        }
    }

}
