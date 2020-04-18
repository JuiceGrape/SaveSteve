using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapType trapType;
    public float cooldownTime;

    [SerializeField]
    protected Animator myAnimator;
    
    public void Start()
    {

    }

    public virtual void Trigger()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>())
        {
            collision.GetComponent<Adventurer>().AttackedByTrap(trapType);
        }
    }
}
