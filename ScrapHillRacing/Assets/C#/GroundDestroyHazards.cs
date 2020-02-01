using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyHazards : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flyinghazard")
        {
            Instantiate(explosion, other.transform.position, Quaternion.identity, null);

            Destroy(other.gameObject);
        }
    }
}
