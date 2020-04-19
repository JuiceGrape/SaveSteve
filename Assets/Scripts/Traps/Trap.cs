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
    [SerializeField]
    protected GameObject cooldownBar;
    [SerializeField]
    protected Transform barFill;
    [SerializeField]
    protected Color cooldownColor;
    [SerializeField]
    protected Color failTimerColor;

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
        StopAllCoroutines();
        StartCoroutine(ButtonCooldown(cooldownTime));
        myCollider.enabled = false;
    }


    public virtual void Trigger(GameObject collisionObject)
    {
        if (collisionObject.GetComponent<Adventurer>().CanDodge(this))
            return;
        isActivated = true;
        myAnimator.SetTrigger("TrapTriggered");
    }

    protected virtual void disableTrap()
    {
        cooldownBar.SetActive(false);
        isArmed = false;
        myCollider.enabled = false;
        myButton.ResetButton();
        isActivated = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>() && isArmed)
        {
            Trigger(collision.gameObject);
        }
    }

    IEnumerator ButtonCooldown (float seconds) {
        cooldownBar.SetActive(true);
        barFill.localScale = new Vector3(0, 1, 1);
        barFill.GetComponent<SpriteRenderer>().color = cooldownColor;

        float current = 0;
        while (current < seconds) {
            barFill.localScale = new Vector3(current / seconds, 1, 1);
            yield return null;
            current += Time.deltaTime;
        }

        disableTrap();
    }

    IEnumerator FailAfter(float seconds)
    {
        cooldownBar.SetActive(true);
        barFill.localScale = new Vector3(0, 1, 1);
        barFill.GetComponent<SpriteRenderer>().color = failTimerColor;

        float current = 0;
        while (current < seconds) {
            barFill.localScale = new Vector3(current / seconds, 1, 1);
            yield return null;
            current += Time.deltaTime;
        }

        if (isArmed && !isActivated)
        {
            disableTrap();
        }
    }
}
