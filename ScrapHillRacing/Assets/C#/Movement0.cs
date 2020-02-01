using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement0 : MonoBehaviour
{

    public float motorForce, steerForce;
    public float forwardForceIncrement;
    public int incrementFrequency;
    public WheelCollider wheel1, wheel2, wheel3, wheel4;

    private float forwardForce;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("IncreaseMotorTorque", 10, incrementFrequency);
    }

    // Update is called once per frame
    void Update()
    {

        float v = Input.GetAxis("Vertical") * motorForce;
        float h = Input.GetAxis("Horizontal") * steerForce;

        wheel1.motorTorque = motorForce;
        wheel2.motorTorque = motorForce;

        wheel3.steerAngle = h;
        wheel4.steerAngle = h;

        rb.AddForce(transform.forward * forwardForce);
    }

    void IncreaseMotorTorque()
    {
        forwardForce += forwardForceIncrement;
    }
}
