using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemSelectorUIElement : MonoBehaviour
{
    public float SelectedBounceHeight;
    public float SelectedBounceSpeed;
    public Quaternion RotationSpeeds = Quaternion.identity;
    
    public UIScrapItem Item;

    private GameObject _model;

    private float wasSelectedTime;

    public void ChangeItem(UIScrapItem item)
    {
        if (_model != null)
            Destroy(_model);
        _model = Instantiate(item.UIObject);
        _model.transform.SetParent(gameObject.transform, false);
        _model.transform.localPosition = Vector3.zero;
        _model.transform.localRotation = Quaternion.identity;
        Item = item;
    }

    public GameObject SceneModelPrefab
    {
        get { return Item.SceneModel; }
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
        _model.transform.localPosition = Vector3.zero;
        //_model.transform.localRotation *= RotationSpeeds;
        if (IsSelected)
        {
            _model.transform.localPosition = new Vector3(
                0.0f,
                (1.0f + Mathf.Sin(SelectedBounceSpeed * (Time.time - wasSelectedTime))) / 2.0f * SelectedBounceHeight,
                0.0f
            );
                
        }

    }
}
