using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHazardEmitter : MonoBehaviour
{
    public GameObject flyingHazard;
    public int maxEmitFrequency;

    private int actualFrequency;

    private void Start()
    {
        int random = Random.Range(1, maxEmitFrequency);

        actualFrequency = random;

        InvokeRepeating("SpawnFlyingHazard", actualFrequency, actualFrequency);
    }

    void SpawnFlyingHazard()
    {
        Instantiate(flyingHazard, transform.position, transform.rotation, null);

        int random = Random.Range(1, maxEmitFrequency);

        actualFrequency = random;
    }
}
