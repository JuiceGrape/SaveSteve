using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AdventurerType
{
    BLUE,
    GREEN,
    PURPLE,
    APPLE
}

public class Adventurer : MonoBehaviour
{
    public AdventurerType type;

    public float speed = 1;

    bool isMoving = true;

    private void FixedUpdate() 
    {
        if (isMoving)
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        else
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void AttackedByTrap()
    {
        Destroy(gameObject);
    }

    public void AttackSteve(Steve steve)
    {
        isMoving = false;
        StartCoroutine(KillSteve(0.5f, steve));
    }

    public void GetConsumed(Steve steve)
    {
        isMoving = false;
        StartCoroutine(DestroyAfter(0.5f));
    }


    
    private IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private IEnumerator KillSteve(float seconds, Steve steve)
    {
        yield return new WaitForSeconds(seconds);
        steve.OnDeath();
    }
}
