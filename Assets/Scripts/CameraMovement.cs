using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float heightJump = 4.0f;
    public float cameraMovementSpeed = 1.0f;
    public float heightSpeed = 1.0f;

    float[] yPositions = new float[3];

    int position = 1;

    bool isDoing;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        yPositions[0] = transform.position.y - heightJump;
        yPositions[1] = transform.position.y;
        yPositions[2] = transform.position.y + heightJump;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-cameraMovementSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(cameraMovementSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (!isDoing && position < 2)
            {
                StartCoroutine(MoveToYPos(++position));
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isDoing && position > 0)
            {
                StartCoroutine(MoveToYPos(--position));
            }
        }
    }

    IEnumerator MoveToYPos(int pos)
    {
        isDoing = true;
        while(Mathf.Abs(transform.position.y - yPositions[pos]) > 0.1)
        {
            Vector3 targetPos = transform.position;
            targetPos.y = yPositions[pos];
            transform.position = Vector3.Lerp(transform.position, targetPos, heightSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        Vector3 newPos = transform.position;
        newPos.y = yPositions[pos];
        transform.position = newPos;
        isDoing = false;
    }
}
