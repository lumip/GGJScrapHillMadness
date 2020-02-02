using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePitch : MonoBehaviour
{
    public float topSpeed = 100; // km per hour
    private float currentSpeed = 0;
    private float pitch = 0;

    void Update()
    {
        currentSpeed = transform.GetComponent<Rigidbody>
        ().velocity.magnitude * 3.6f;
        pitch = currentSpeed / topSpeed + 0.5f;

        pitch = Mathf.Clamp(pitch, 0.5f, 2f);

        transform.GetComponent<AudioSource>().pitch =
        pitch;

        if (pitch < 1.5) ;

    }
}