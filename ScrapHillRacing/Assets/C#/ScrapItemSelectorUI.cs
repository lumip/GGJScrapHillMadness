using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemSelectorUI : MonoBehaviour
{
    public int numberOfItems;
    public float listWidth;
    public float SelectedBounceHeight;
    public float SelectedBounceSpeed;

    public int selected = 0;

    private GameObject[] currentItems;

    public GameObject[] ItemPrefabs;

    public GameObject SelectedItem
    {
        get
        {
            return currentItems[selected];
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
        
        currentItems = new GameObject[numberOfItems];
        for (int i = 0; i < numberOfItems; ++i)
        {
            int randomIndex = (int)(Random.value * ItemPrefabs.Length);
            currentItems[i] = Instantiate(ItemPrefabs[randomIndex]);
            currentItems[i].transform.SetParent(gameObject.transform);
            currentItems[i].transform.localPosition = GetItemBasePos(i);
            currentItems[i].transform.localRotation = Quaternion.identity;
        }
    }

    private float selectionButtonWait = 0.0f;
    public float SelectionButtonCooldown = .1f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfItems; ++i)
        {
            currentItems[i].transform.localRotation *= Quaternion.Euler(.2f, 0, .5f);
            currentItems[i].transform.localPosition = GetItemBasePos(i);
        }
        currentItems[selected].transform.localPosition +=
            new Vector3(0, (1.0f + Mathf.Sin(SelectedBounceSpeed * Time.time)) / 2.0f * SelectedBounceHeight, 0);

        if (selectionButtonWait <= 0.0f)
        {
            bool isLeft= (Input.GetAxis("ItemSelection") < -0.1f) ? true : false;
            bool isRight = (Input.GetAxis("ItemSelection") > 0.1f) ? true : false;

            if (isRight)
            {
                selected = (selected >= numberOfItems - 1) ? numberOfItems - 1 : selected + 1;
                selectionButtonWait = SelectionButtonCooldown;
            }
            if (isLeft)
            {
                selected = (selected <= 0) ? 0 : selected - 1;
                selectionButtonWait = SelectionButtonCooldown;
            }
        }

        selectionButtonWait = Mathf.Max(0.0f, selectionButtonWait - Time.deltaTime);
    }
}
