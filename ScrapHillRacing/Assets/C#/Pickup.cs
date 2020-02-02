using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject[] scrapParts = new GameObject[6];

    public float rotationSpeed;

    private GameObject scrapSpawn;

    void Start()
    {
        int random = Random.Range(0, 6);

        scrapSpawn = Instantiate(scrapParts[random], transform.position, Quaternion.identity, this.gameObject.transform);
    }

    private void FixedUpdate()
    {
        if (scrapSpawn != null)
        {
            scrapSpawn.transform.Rotate(Vector3.up * rotationSpeed);
        }
    }
}
