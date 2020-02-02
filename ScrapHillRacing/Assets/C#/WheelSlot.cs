using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSlot : MonoBehaviour
{
    public GameObject InitialWheelModelPrefab;
    public WheelCollider WheelCollider;

    private GameObject wheelModel = null;

    public bool HasWheel
    {
        get
        {
            return wheelModel != null;
        }
    }


    public void ChangeWheelModel(GameObject newWheel)
    {
        if (wheelModel)
            Destroy(wheelModel);
        wheelModel = newWheel;
        wheelModel.transform.SetParent(gameObject.transform, false);
        wheelModel.transform.localPosition = Vector3.zero;
        wheelModel.transform.localRotation = Quaternion.identity;
        WheelCollider.enabled = true;
    }

    public float WheelLoseForceMagnitude = 100.0f;

    public void LoseWheel()
    {
        if (wheelModel != null)
        {
            wheelModel.transform.SetParent(null, true);
            wheelModel.AddComponent<Rigidbody>();

            Vector3 force = Random.insideUnitSphere * WheelLoseForceMagnitude;
            force.y = Mathf.Abs(force.y);
            wheelModel.GetComponent<Rigidbody>().AddForce(force);


            Collider collider = wheelModel.GetComponent<CapsuleCollider>();
            if (collider != null)
            {
                foreach (var carPart in GameObject.FindGameObjectsWithTag("Car"))
                {
                    foreach (var carCollider in carPart.GetComponents<Collider>())
                    {
                        Physics.IgnoreCollision(collider, carCollider);
                    }
                }
                collider.enabled = true;
            }

            DestroySelf destroy = wheelModel.GetComponent<DestroySelf>();
            if (destroy != null)
            {
                destroy.enabled = true;
            }

            WheelCollider.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeWheelModel(Instantiate(InitialWheelModelPrefab));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
