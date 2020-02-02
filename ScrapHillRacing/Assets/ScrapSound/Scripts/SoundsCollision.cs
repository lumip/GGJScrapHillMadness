using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsCollision : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private void OnTriggerEnter(Collider hazard)
    {

        if (hazard.tag == "hazard")
        {
            audioSource1.Play();
        }

        if (hazard.tag == "flyinghazard")
        {
            audioSource2.Play();
        }
    }
}
