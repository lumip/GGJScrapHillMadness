using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemSelectorUIElement : MonoBehaviour
{
    public float SelectedBounceHeight;
    public float SelectedBounceSpeed;
    public Quaternion RotationSpeeds = Quaternion.identity;
    
    public GameObject Model;

    private float wasSelectedTime;

    public void ChangeModel(GameObject model)
    {
        Destroy(Model);
        Model = model;
        Model.transform.SetParent(gameObject.transform, false);
        Model.transform.localPosition = Vector3.zero;
        Model.transform.localRotation = Quaternion.identity;
    }

    public bool IsSelected
    {
        get; private set;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Select()
    {
        IsSelected = true;
        wasSelectedTime = Time.time;
    }

    public void Deselect()
    {
        IsSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        Model.transform.localPosition = Vector3.zero;
        Model.transform.localRotation *= RotationSpeeds;
        if (IsSelected)
        {
            Model.transform.localPosition = new Vector3(
                0.0f,
                (1.0f + Mathf.Sin(SelectedBounceSpeed * (Time.time - wasSelectedTime))) / 2.0f * SelectedBounceHeight,
                0.0f
            );
                
        }

    }
}
