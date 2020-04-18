using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AdventurerType
{
    BASIC
}

public class Adventurer : MonoBehaviour
{
    public AdventurerType type;

    public float speed = 1;
    [SerializeField]
    private List<TrapType> immuneToTraps;

    private void FixedUpdate() 
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    public void AttackedByTrap(TrapType trapType)
    {

    }

    public void AttackSteve(Steve steve)
    {

    }

    public void GetConsumed(Steve steve)
    {
        StartCoroutine(DestroyAfter(0.5f));
    }


    
    private IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
