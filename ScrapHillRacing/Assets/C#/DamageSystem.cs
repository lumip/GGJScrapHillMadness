using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int health;
    public int hazardDamage;

    public float groundHazardForce;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }


    void TakeDamage (int damage)
    {
        health -= hazardDamage;
    }

    private void OnTriggerEnter(Collider hazard)
    {
        if (hazard.tag == "hazard" || hazard.tag == "flyinghazard")
        {
            TakeDamage(hazardDamage);
        }

        if (hazard.tag == "hazard")
        {
            float random1 = Random.Range(0, 5);
            float random2 = Random.Range(0, 5);
            rb.AddForce ((Vector3.up + new Vector3(random1, 0, random2).normalized) * groundHazardForce);
        }
    }
}
