using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompOccasionally : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
       // StartCoroutine(chompAfterAndRepeat(5.0f));
    }

    private void OnMouseDown() 
    {
        animator.SetTrigger("StartEat");
    }

    IEnumerator chompAfterAndRepeat(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("StartEat");
        StartCoroutine(chompAfterAndRepeat(seconds));
    }

}
