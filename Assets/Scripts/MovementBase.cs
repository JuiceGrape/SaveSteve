using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    UP,
    DOWN,
    CLOSED
}

public class MovementBase : MonoBehaviour
{
    public Sprite UpSign;
    public Sprite DownSign;
    public Sprite ClosedSign;
    public SpriteRenderer sign;
     public List<MovementState> PossibleStates;

    public int currentState;

    public Transform UpperTarget;
    public Transform LowerTarget;

    void Start()
    {
        SetSign();
    }
    void OnMouseDown()
    {
        currentState++;
        if(currentState >= PossibleStates.Count)
        {
            currentState = 0;
        }

       SetSign();
    }

    void SetSign()
    {
        switch(PossibleStates[currentState])
        {
        case MovementState.UP:
            sign.sprite = UpSign;
            break;
        case MovementState.CLOSED:
            sign.sprite = ClosedSign;
            break;
        case MovementState.DOWN:
            sign.sprite = DownSign;
             break;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        Adventurer enemy = other.GetComponent<Adventurer>();

        if (enemy == null)
        {
            return;
        }

        //TODO: Fade out and in
        switch(PossibleStates[currentState]) 
        {
            case MovementState.UP:
                enemy.transform.position = UpperTarget.position;
                break;
            case MovementState.DOWN:
                enemy.transform.position = LowerTarget.position;
                break;
        }
    }
}
