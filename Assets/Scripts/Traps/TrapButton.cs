using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TrapButton : MonoBehaviour
{
    public Trap myTrap;

    [SerializeField]
    private Sprite ButtonUnpressed = null;
    [SerializeField]
    private Sprite ButtonPressed = null;

    private SpriteRenderer mySprite;

    private float trapCoolDown;
    public bool isTriggered = false;

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
        Debug.Log("Pressed");
        if (!isTriggered)
        {
            isTriggered = true;
            mySprite.sprite = ButtonPressed;
            myTrap.ArmTrap();
        }
    }

    public void activateCooldown()
    {
        StartCoroutine(cooldownTimer());
    }

    private void OnMouseDown()
    {
        buttonWasPressed();
    }

    private IEnumerator cooldownTimer()
    {
        yield return new WaitForSeconds(trapCoolDown);
        ResetButton();
    }

    public void ResetButton()
    {   
        mySprite.sprite = ButtonUnpressed;
        isTriggered = false;
    }
}
