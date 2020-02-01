using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement0 : MonoBehaviour
{

    public GameObject carObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = new Vector3(carObject.transform.position.x, carObject.transform.position.y + 10f, 41.04f);
        transform.position = newPos;
    }
}
