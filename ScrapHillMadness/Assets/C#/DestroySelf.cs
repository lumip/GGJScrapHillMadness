using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float Delay = 2.0f;

    void Start()
    {
        Destroy(gameObject, Delay);
    }
}
