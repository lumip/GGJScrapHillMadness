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

    private int _selected = 0; // currently selected item index

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

    public int Selected
    {
        get { return _selected; }
        private set
        {
            Debug.Assert(value >= 0 && value < numberOfItems);
            if (value != _selected)
            {
                elements[_selected].Deselect();
                _selected = value;
                elements[_selected].Select();
            }
        }
    }

    /// <summary>
    /// Returns the prefab for the 3d scene model of the currently selected scrap part
    /// </summary>
    private GameObject SelectedSceneModelPrefab
    {
        get
        {
            return elements[Selected].SceneModelPrefab;
        }
    }

    public UIScrapItem GetRandomItem()
    {
        int randomIndex = (int)(Random.value * ItemPrefabs.Length);
        return ItemPrefabs[randomIndex];
    }

    /// <summary>
    /// Returns a prefab of the scene model for the current selection and generates a new item for the slot.
    /// </summary>
    /// <returns></returns>
    public GameObject ConsumeSelected()
    {
        GameObject sceneModel = SelectedSceneModelPrefab;
        elements[Selected].ChangeItem(GetRandomItem());
        return sceneModel;
    }

    private Vector3 GetItemBasePos(int index)
    {
        float distance = listWidth / ((float)numberOfItems - 1.0f);
        return new Vector3(-(listWidth / 2) + index * distance, 20.2f);
    }

    // Start is called before the first frame update
    void Start()
    {        
        elements = new ScrapItemSelectorUIElement[numberOfItems];
        for (int i = 0; i < numberOfItems; ++i)
        {
            elements[i] = Instantiate(ElementPrefab.gameObject).GetComponent<ScrapItemSelectorUIElement>();
            elements[i].gameObject.transform.SetParent(gameObject.transform);
            elements[i].gameObject.transform.localPosition = GetItemBasePos(i);

            elements[i].ChangeItem(GetRandomItem());
        }
        Selected = numberOfItems / 2;
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
                Selected = (Selected + direction + numberOfItems) % numberOfItems;
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
