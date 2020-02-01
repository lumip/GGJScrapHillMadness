using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSlot : MonoBehaviour
{
    public GameObject InitialWheelPrefab;

    private GameObject wheelModel;

    public void ChangeWheelModel(GameObject newWheel)
    {
        Destroy(wheelModel);
        wheelModel = newWheel;
        wheelModel.transform.SetParent(gameObject.transform, false);
        wheelModel.transform.localPosition = Vector3.zero;
        wheelModel.transform.localRotation = Quaternion.identity;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeWheelModel(Instantiate(InitialWheelPrefab));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
