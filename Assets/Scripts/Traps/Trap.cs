using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapType trapType;
    public float cooldownTime;

    [SerializeField]
    protected Animator myAnimator;

    protected Collider2D myCollider;
    
    public void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myCollider.isTrigger = true;
        myCollider.enabled = false;
    }

    public virtual void Trigger()
    {

    }
    
    public void ToggleHitBox()
    {
        StartCoroutine(enumeratorToggleHitbox());
    }

    private IEnumerator enumeratorToggleHitbox()
    {
        myCollider.enabled = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        myCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>())
        {
            collision.GetComponent<Adventurer>().AttackedByTrap(trapType);
            Debug.Log("Test");
        }
    }
}
