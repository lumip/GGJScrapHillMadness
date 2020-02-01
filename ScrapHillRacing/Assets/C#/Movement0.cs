using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement0 : MonoBehaviour
{

    public float motorForce, steerForce;
    public WheelCollider wheel1, wheel2, wheel3, wheel4;


    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {

        float v = Input.GetAxis("Vertical") * motorForce;
        float h = Input.GetAxis("Horizontal") * steerForce;

        wheel1.motorTorque = 2000;
        wheel2.motorTorque = 2000;

        wheel3.steerAngle = h;
        wheel4.steerAngle = h;





    }
}
