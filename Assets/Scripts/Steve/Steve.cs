using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : MonoBehaviour
{
    public List<AdventurerType> HungerList;
    public HungerBubble bubble;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        bubble.Populate(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnDeath();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            OnChomp();
        }
    }

    public void OnDeath()
    {
        animator.SetTrigger("Dead");
    }

    public void ChangeHuner(List<AdventurerType> hunger)
    {

        HungerList = hunger;
        bubble.Populate(this);
    }

    void OnChomp()
    {
        animator.SetTrigger("StartEat");
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
}
