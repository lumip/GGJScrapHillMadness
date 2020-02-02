using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapItemSelectorUI : MonoBehaviour
{
    /// <summary>
    /// how many item slotsare in our list
    /// </summary>
    public int numberOfItems; 

    /// <summary>
    /// how wide the list is on the screen, in px
    /// </summary>
    public float listWidth;

    private int selected = 0; // currently selected item index

    /// <summary>
    /// UI slot instances
    /// </summary>
    private ScrapItemSelectorUIElement[] elements;

    /// <summary>
    /// Prefab for a UI slot (screen space game object with ScrapItemSelectorUIElement component)
    /// </summary>
    public ScrapItemSelectorUIElement ElementPrefab;

    /// <summary>
    /// Inventory: our available scrap parts
    /// </summary>
    public UIScrapItem[] ItemPrefabs;

    /// <summary>
    /// Returns the prefab for the 3d scene model of the currently selected scrap part
    /// </summary>
    public GameObject SelectedSceneModelPrefab
    {
        get
        {
            return elements[selected].SceneModelPrefab;
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

            int randomIndex = (int)(Random.value * ItemPrefabs.Length);

            elements[i].ChangeItem(ItemPrefabs[randomIndex]);
        }
        elements[selected].Select();
    }

    private float selectionButtonWait = 0.0f;
    public float SelectionButtonCooldown = .2f;

    // Update is called once per frame
    void Update()
    {
        if (selectionButtonWait <= 0.0f)
        {
            int direction = (Input.GetAxis("ItemSelection") < -0.1f) ? -1 : (Input.GetAxis("ItemSelection") > 0.1 ? 1 : 0);

            if (direction != 0)
            {
                elements[selected].Deselect();
                selected = (selected + direction + numberOfItems) % numberOfItems;
                elements[selected].Select();
                selectionButtonWait = SelectionButtonCooldown;
            }
        }

        selectionButtonWait = Mathf.Max(0.0f, selectionButtonWait - Time.deltaTime);
    }
}

[System.Serializable]
public struct UIScrapItem
{
    /// <summary>
    /// The 3d scene model of the scrap item
    /// </summary>
    public GameObject SceneModel;

    /// <summary>
    /// The 2d image game object of the scrap item (to be displayed on the UI/HUD)
    /// </summary>
    public GameObject UIObject;
}
