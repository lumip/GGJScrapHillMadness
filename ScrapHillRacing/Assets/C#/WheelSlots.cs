using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSlots : MonoBehaviour
{
    public GameObject HighlightMeshPrefab;

    public WheelSlot[] Slots;
    private int selected;
    public ScrapItemSelectorUI itemSelectorUI;

    private int Selected
    {
        get { return selected; }
        set
        {
            Debug.Assert(value < Slots.Length && value >= 0);
            selected = value;
            highlightMesh.transform.SetParent(Slots[selected].transform, false);
        }
    }

    private GameObject highlightMesh;

    // Start is called before the first frame update
    void Start()
    {
        highlightMesh = GameObject.Instantiate(HighlightMeshPrefab);
        lastTime = Time.time;
    }

    private float lastTime;
    private float selectionButtonWait = 0.0f;
    public float SelectionButtonCooldown = .2f;


    // Update is called once per frame
    void Update()
    {
        if (selectionButtonWait <= 0.0f)
        {
            bool isLeft = (Input.GetAxis("WheelSelection") < -0.1f) ? true : false;
            bool isRight = (Input.GetAxis("WheelSelection") > 0.1f) ? true : false;

            if (isRight)
            {
                Selected = (Selected + 1) % Slots.Length;
                selectionButtonWait = SelectionButtonCooldown;
            }
            if (isLeft)
            {
                Selected = (Selected - 1) % Slots.Length;
                selectionButtonWait = SelectionButtonCooldown;
            }
        }

        selectionButtonWait = Mathf.Max(0.0f, selectionButtonWait - Time.deltaTime);

        if (Input.GetButtonDown("PlacePart"))
        {
            Debug.Log(itemSelectorUI.SelectedItem);
            Slots[selected].ChangeWheelModel(Instantiate(itemSelectorUI.SelectedItem));
        }
    }
}
