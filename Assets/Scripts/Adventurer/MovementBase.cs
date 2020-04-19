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
    public bool roundRobin = false;
    public bool isClickable = true;
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
        if (isClickable)
            NextState();
    }

    public void SetState(MovementState state)
    {
        int index = 0;
        foreach(MovementState sta in PossibleStates)
        {
            if (sta  == state)
            {
                currentState = index;
                SetSign();
                return;
            }
            index++;
        }
    }

    public void NextState()
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
        if (roundRobin)
            NextState();
    }
}
