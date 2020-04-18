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

    public GameObject swoosh;
    public GameObject blood;

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
        Die();
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

    public void Die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    
    private IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Die();
    }

    private IEnumerator KillSteve(float seconds, Steve steve)
    {
        Instantiate(swoosh, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(seconds);
        steve.OnDeath();
    }
}
