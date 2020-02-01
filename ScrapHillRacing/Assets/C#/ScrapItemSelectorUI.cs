using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemSelectorUI : MonoBehaviour
{
    public int numberOfItems;
    public float listWidth;

    public int selected = 0;

    private ScrapItemSelectorUIElement[] elements;

    public ScrapItemSelectorUIElement ElementPrefab;
    public GameObject[] ItemPrefabs;

    public GameObject SelectedItem
    {
        get
        {
            return elements[selected].Model;
        }
    }

    private Vector3 GetItemBasePos(int index)
    {
        float distance = listWidth / ((float)numberOfItems - 1.0f);
        return new Vector3(-(listWidth / 2) + index * distance, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        selected = numberOfItems / 2;
        
        elements = new ScrapItemSelectorUIElement[numberOfItems];
        for (int i = 0; i < numberOfItems; ++i)
        {
            elements[i] = Instantiate(ElementPrefab.gameObject).GetComponent<ScrapItemSelectorUIElement>();
            elements[i].gameObject.transform.SetParent(gameObject.transform);
            elements[i].gameObject.transform.localPosition = GetItemBasePos(i);
            elements[i].gameObject.transform.localRotation = Quaternion.identity;

            int randomIndex = (int)(Random.value * ItemPrefabs.Length);
            elements[i].RotationSpeeds = Quaternion.Lerp(Quaternion.identity, Random.rotationUniform, 0.01f);

            elements[i].ChangeModel(Instantiate(ItemPrefabs[randomIndex]));
        }
        elements[selected].Select();
    }

    private float selectionButtonWait = 0.0f;
    public float SelectionButtonCooldown = .1f;

    // Update is called once per frame
    void Update()
    {
        if (selectionButtonWait <= 0.0f)
        {
            bool isLeft = (Input.GetAxis("ItemSelection") < -0.1f) ? true : false;
            bool isRight = (Input.GetAxis("ItemSelection") > 0.1f) ? true : false;

            if (isRight)
            {
                elements[selected].Deselect();
                selected = (selected >= numberOfItems - 1) ? numberOfItems - 1 : selected + 1;
                selectionButtonWait = SelectionButtonCooldown;
                elements[selected].Select();
            }
            if (isLeft)
            {
                elements[selected].Deselect();
                selected = (selected <= 0) ? 0 : selected - 1;
                selectionButtonWait = SelectionButtonCooldown;
                elements[selected].Select();
            }
        }

        selectionButtonWait = Mathf.Max(0.0f, selectionButtonWait - Time.deltaTime);
    }
}
