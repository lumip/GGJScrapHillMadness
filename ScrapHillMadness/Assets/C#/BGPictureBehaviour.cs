using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGPictureBehaviour : MonoBehaviour
{
    public GameObject target;
    public float animSmooth;

    private float y;

    private Vector3 nextpos;

    private Vector3 velocity = Vector3.zero;

    private float distance;

    void Start()
    {
        distance = Random.Range(15, 30);

        y = transform.position.y;
    }

    void FixedUpdate()
    {
        transform.LookAt(target.transform.position, Vector3.up);

        nextpos = new Vector3(transform.position.x, y + Mathf.PingPong(Time.time * 10, distance), transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, nextpos, ref velocity, animSmooth);
    }
}
