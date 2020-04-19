using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : Trap
{
    public GameObject platform;
    private Rigidbody2D myBody;

    private Vector3 velocity;

    private RotateRock myRotation;

    private void Start()
    {
        myRotation = GetComponent<RotateRock>();
        velocity = Vector3.zero;
        base.Start();
    }

    private void Update()
    {
        if (myBody != null)
        {
            myBody.velocity = velocity;
        }
    }

    public override void ArmTrap()
    {
        myButton.transform.parent = null;
        Destroy(platform);
        myCollider.enabled = true;
        StartCoroutine(fallDown());
    }

    private IEnumerator fallDown()
    {
        float time = 0;
        float seconds = .75f;

        Vector3 startLocation = this.transform.position;
        Vector3 endLocation = this.transform.position -= new Vector3(0, 1.5f, 0);
        while (time / seconds < 1)
        {
            Vector3 result = Vector3.Lerp(startLocation, endLocation, time / seconds);
            this.transform.position = result;
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }

        myBody = this.gameObject.AddComponent<Rigidbody2D>();
        myBody.gravityScale = 0;
        
        myRotation.enabled = true;
        velocity = new Vector3(-2,0,0);
        myRotation.rotateSpeed = 300;

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Adventurer>())
        {
            collision.GetComponent<Adventurer>().Die();
        }
        if (collision.GetComponent<RockWall>())
        {
            Destroy(this.gameObject);
        }
    }
}
