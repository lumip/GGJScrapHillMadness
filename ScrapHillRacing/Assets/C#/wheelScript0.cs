using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelScript0 : MonoBehaviour
{
    public bool isFucked = false;
    public WheelCollider wheel;
    public float fuckeryAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFucked) 
        {
            StartCoroutine("wheelFuckery");
            isFucked = false;
        }
    }

    IEnumerator wheelFuckery() 
    {
        Debug.Log("lol");
        wheel.suspensionDistance = fuckeryAmount;
        yield return new WaitForSeconds(0.2f);
        wheel.suspensionDistance = 0.61f;
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("wheelFuckery");
    }


}
