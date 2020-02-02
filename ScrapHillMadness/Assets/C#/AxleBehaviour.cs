using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleBehaviour : MonoBehaviour
{
    public float rotationSpeed;

    void FixedUpdate()
    {
        transform.Rotate (rotationSpeed, 0, 0 );
    }
}
