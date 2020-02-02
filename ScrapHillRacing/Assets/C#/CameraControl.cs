using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;

    public float smoothing;

    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        transform.rotation = Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.transform.position + positionOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothing);
    }
}
