using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompOccasionally : MonoBehaviour
{
    Animator animator;
    [SerializeField] private string animation;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
       // StartCoroutine(chompAfterAndRepeat(5.0f));
    }

    private void OnMouseDown() 
    {
        animator.SetTrigger(animation);
    }

    IEnumerator chompAfterAndRepeat(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("StartEat");
        StartCoroutine(chompAfterAndRepeat(seconds));
    }

}
