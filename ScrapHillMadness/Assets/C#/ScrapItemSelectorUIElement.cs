﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemSelectorUIElement : MonoBehaviour
{
    public float SelectedBounceHeight; // in px
    public float SelectedBounceSpeed;
    
    public UIScrapItem Item;

    private GameObject _uiModel; // ui image instance

    private float wasSelectedTime;

    public void ChangeItem(UIScrapItem item)
    {
        if (_uiModel != null)
            Destroy(_uiModel);
        _uiModel = Instantiate(item.UIObject);
        _uiModel.transform.SetParent(gameObject.transform, false);
        _uiModel.transform.localPosition = Vector2.zero;
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
        _uiModel.transform.localPosition = Vector3.zero;
        if (IsSelected) // wiggle in excitement if selected :)
        {
            _uiModel.transform.localPosition = new Vector3(
                0.0f,
                (1.0f + Mathf.Sin(SelectedBounceSpeed * (Time.time - wasSelectedTime))) / 2.0f * SelectedBounceHeight
            );
                
        }

    }
}
