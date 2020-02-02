using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{

    public float motorForce, steerForce;
    public float forwardForceIncrement;
    public int incrementFrequency;

    public WheelInfo[] FrontWheelInfos;
    public WheelInfo[] BackWheelInfos;

    private float forwardForce;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("IncreaseMotorTorque", 10, incrementFrequency);
    }

    void UpdateWheelVisuals(WheelInfo wheel)
    {
        if (wheel.WheelCollider.enabled)
        {
            Vector3 position;
            Quaternion rotation;
            wheel.WheelCollider.GetWorldPose(out position, out rotation);
            wheel.WheelVisual.transform.rotation = rotation;
            wheel.WheelVisual.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical") * motorForce;
        float h = Input.GetAxis("Horizontal") * steerForce;

        foreach (var wheelInfo in FrontWheelInfos)
        {
            var wheel = wheelInfo.WheelCollider;
            wheel.steerAngle = h;
            UpdateWheelVisuals(wheelInfo);
        }

        foreach (var wheelInfo in BackWheelInfos)
        {
            wheelInfo.WheelCollider.motorTorque = motorForce;
            UpdateWheelVisuals(wheelInfo);
        }
        
        rb.AddForce(transform.forward * forwardForce);
    }

    void IncreaseMotorTorque()
    {
        forwardForce += forwardForceIncrement;
    }
}

[System.Serializable]
public struct WheelInfo
{
    public WheelCollider WheelCollider;
    public GameObject WheelVisual;
}
