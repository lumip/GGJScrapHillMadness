using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemUIElementBehavior : MonoBehaviour
{
    public float SelectedBounceHeight;
    public float SelectedBounceSpeed;
    public Quaternion RotationSpeeds = Quaternion.identity;

    private float wasSelectedTime;

    public bool IsSelected
    {
        get; private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Select()
    {
        IsSelected = true;
        wasSelectedTime = Time.time;
    }

    void Deselect()
    {
        IsSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation *= RotationSpeeds;
        if (IsSelected)
        {
            transform.localPosition = new Vector3(
                0.0f,
                (1.0f + Mathf.Sin(SelectedBounceSpeed * (Time.time - wasSelectedTime))) / 2.0f * SelectedBounceHeight,
                0.0f
            );
                
        }

    }
}
