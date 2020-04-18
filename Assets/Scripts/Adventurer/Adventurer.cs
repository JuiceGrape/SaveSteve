using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    [SerializeField]
    private List<TrapType> immuneToTraps;

    public float speed = 1;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    public void AttackedByTrap(TrapType trapType)
    {

    }
}
