using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TrapButton : MonoBehaviour
{
    public Trap myTrap;

    [SerializeField]
    private Sprite ButtonUnpressed;
    [SerializeField]
    private Sprite ButtonPressed;

    private SpriteRenderer mySprite;

    private float trapCoolDown;
    private bool isTriggered;

    private void Start()
    {
        if (myTrap == null)
        {
            Debug.LogError("BUTTON WAS NOT ASSIGNED A TRAP", this.gameObject);
        }
        else
        {
            this.trapCoolDown = myTrap.cooldownTime;
        }
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void buttonWasPressed()
    {
        if (!isTriggered)
        {
            StartCoroutine(cooldownTimer());
            myTrap.Trigger();
        }
    }


    private void OnMouseDown()
    {
        buttonWasPressed();
    }

    private IEnumerator cooldownTimer()
    {
        isTriggered = true;
        mySprite.sprite = ButtonPressed;
        yield return new WaitForSeconds(trapCoolDown);
        mySprite.sprite = ButtonUnpressed;
        isTriggered = false;
    }
}
