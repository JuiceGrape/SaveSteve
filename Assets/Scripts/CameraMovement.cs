using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraMovementSpeed = 1.0f;
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
    }
}
