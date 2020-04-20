using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : MonoBehaviour
{
    public List<AdventurerType> HungerList;
    public HungerBubble bubble;

    public GameMenu menu;
    Animator animator;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        bubble.Populate(this);
        audioSource = this.GetComponent<AudioSource>();
    }

    public void OnDeath()
    {
        animator.SetTrigger("Dead");
        StartCoroutine(FailAfter(1.0f));
    }

    public void ChangeHunger(List<AdventurerType> hunger)
    {

        HungerList = hunger;
        bubble.Populate(this);
    }

    void OnChomp()
    {
        animator.SetTrigger("StartEat");
    }

    void PlayChomp()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Adventurer enemy = other.GetComponent<Adventurer>();

        if (enemy == null)
        {
            return;
        }

        if (HungerList.Contains(enemy.type))
        {
            enemy.GetConsumed(this);
            OnChomp();
            HungerList.Remove(enemy.type);
            bubble.Populate(this);
        }
        else
        {
            enemy.AttackSteve(this);
        }
    }

    IEnumerator FailAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        menu.Fail();
    }

    public void Success()
    {
        animator.SetTrigger("Happy");
    }

}
