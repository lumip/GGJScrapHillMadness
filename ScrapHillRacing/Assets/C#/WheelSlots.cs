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
    }

    private float selectionButtonWait = 0.0f;
    public float SelectionButtonCooldown = 0.2f;

    // Update is called once per frame
    void Update()
    {

        if (selectionButtonWait <= 0.0f)
        {
            int direction = (Input.GetAxis("WheelSelection") < -0.1f) ? -1 : (Input.GetAxis("WheelSelection") > 0.1 ? 1 : 0);

            if (direction != 0)
            {
                Selected = (Selected + direction + Slots.Length) % Slots.Length;
                selectionButtonWait = SelectionButtonCooldown;
            }
        }

        selectionButtonWait = Mathf.Max(0.0f, selectionButtonWait - Time.deltaTime);

        if (Input.GetButtonDown("PlacePart"))
        {
            Slots[Selected].ChangeWheelModel(Instantiate(itemSelectorUI.ConsumeSelected()));
        }
    }
}
