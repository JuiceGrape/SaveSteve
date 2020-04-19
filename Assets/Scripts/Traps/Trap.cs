using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public float cooldownTime;
    [SerializeField]
    protected Animator myAnimator;
    [SerializeField]
    protected TrapButton myButton = null;

    public float FailTime = 5.0f;

    protected Collider2D myCollider;

    protected bool isArmed;
    protected bool isActivated;

    public void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myCollider.isTrigger = true;
        myCollider.enabled = false;
    }

    public virtual void ArmTrap()
    {
        myCollider.enabled = true;
        if (FailTime > 0)
        {
            StartCoroutine(FailAfter(FailTime));
        }
        isArmed = true;
    }

    public virtual void FinishedAttacking()
    {
        isArmed = false;
        myButton.activateCooldown();
        myCollider.enabled = false;
    }

    public virtual void Trigger(GameObject collisionObject = null)
    {
        isActivated = true;
        myAnimator.SetTrigger("TrapTriggered");
    }

    protected virtual void disableTrap()
    {
        isArmed = false;
        myCollider.enabled = false;
        myButton.ResetButton();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>() && isArmed)
        {
            Trigger(collision.gameObject);
        }
    }

    IEnumerator FailAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (isArmed && !isActivated)
        {
            disableTrap();
        }
    }
}
