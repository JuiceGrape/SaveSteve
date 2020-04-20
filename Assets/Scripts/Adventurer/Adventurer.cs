using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AdventurerType
{
    BLUE,
    GREEN,
    PURPLE,
    GOLDEN
}

public class Adventurer : MonoBehaviour
{
    public AdventurerType type;

    public GameObject swoosh;
    public GameObject blood;

    public float speed = 1;

    public bool isMoving = true;

    private Rigidbody2D myRigidBody;

    Spawner spawner;

    Animator animator;
    private void Start()
    {
        this.myRigidBody = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("IsMoving", isMoving);

        if (transform.position.y < -10)
        {
            Die();
        }
    }

    public void SetSpawner(Spawner spawn)
    {
        spawner = spawn;
    }

    private void FixedUpdate() 
    {
        if (isMoving)
            myRigidBody.velocity = new Vector2(speed, 0);
        else
            myRigidBody.velocity = new Vector2(0, 0);
    }

    public void AttackedByTrap()
    {
        Die(); 
    }

    public bool CanDodge(Trap trap)
    {
        switch(type)
        {
            case AdventurerType.BLUE:
                return trap is Pitfall;
            case AdventurerType.GREEN:
                return trap is Mimic;
            case AdventurerType.PURPLE:
                return trap is Crusher;
            case AdventurerType.GOLDEN:
                return true;
        }
        return false;
    }

    public void FallInPit(float middleOfPit)
    {
        isMoving = false;
        myRigidBody.gravityScale = 5;
        StartCoroutine(fallTurn());

    }

    private IEnumerator fallTurn()
    {
        int zRotator = -1;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            zRotator = 1;
        }

        for (int z = 0; z < 90; z++)
        {
            this.transform.Rotate(new Vector3(0, 0, zRotator));
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }

    }

    public void AttackSteve(Steve steve)
    {
        isMoving = false;
        StartCoroutine(KillSteve(0.5f, steve));
    }

    public void GetConsumed(Steve steve)
    {
        isMoving = false;
        StartCoroutine(DestroyAfter(0.7f));
    }

    public void Die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        if (spawner != null)
            spawner.RemoveAdventurer(gameObject);
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

    public void WaitForTime(float seconds)
    {
        StartCoroutine(Wait(seconds));
    }
    private IEnumerator Wait(float seconds)
    {
        isMoving = false;
        yield return new WaitForSeconds(seconds);
        isMoving = true;
    }
}
