using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustGo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
