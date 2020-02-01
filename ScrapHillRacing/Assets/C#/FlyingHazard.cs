using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHazard : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 5);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (transform.forward * speed));
    }
}
