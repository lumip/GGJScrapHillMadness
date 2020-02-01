using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    public float baseSpeed;
    public float throttleSpeed;
    public float steeringSpeed;
    public float brokenSteeringEffect;

    public GameObject[] wheelsRight     = new GameObject[2];
    public GameObject[] wheelsLeft      = new GameObject[2];
    public GameObject[] wheelInventory  = new GameObject[4];
    public GameObject[] scrapInventory  = new GameObject[5];

    public Transform shieldSlot_Right;
    public Transform shieldSlot_Left;
    public Transform shieldSlot_Top;

    private int brokenWheelSteeringEffect = 0;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        CheckWheels();

        WheelFixTest();
    }

    void Movement()
    {
        Vector3 currentPos = transform.position;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 nextPos = currentPos + new Vector3(h * steeringSpeed + (brokenWheelSteeringEffect * brokenSteeringEffect), 0, baseSpeed + (v * throttleSpeed));


        rb.AddForce(nextPos - currentPos);
    }

    void CheckWheels()
    {
        int rightWheelsAmount = -wheelsRight[0].transform.childCount - wheelsRight[1].transform.childCount;
        int leftWheelsAmount = wheelsLeft[0].transform.childCount + wheelsLeft[1].transform.childCount;

        brokenWheelSteeringEffect = rightWheelsAmount + leftWheelsAmount;
    }

    void WheelFixTest()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoseWheel(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoseWheel(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoseWheel(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoseWheel(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AddWheel(0,0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AddWheel(1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            AddWheel(2, 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            AddWheel(3, 3);
        }
    }

    // wheel index: 0 = Rear Left, 1 = Front Left, 2 = Rear Right, 3 = Front Right
    void LoseWheel (int wheelIndex)
    {
        if (wheelIndex == 0)
        {
            if (wheelsLeft[0].transform.childCount > 0)
            {
                Destroy(wheelsLeft[0].transform.GetChild(0).gameObject);
            }
        }

        if (wheelIndex == 1)
        {
            if (wheelsLeft[1].transform.childCount > 0)
            {
                Destroy(wheelsLeft[1].transform.GetChild(0).gameObject);
            }
        }

        if (wheelIndex == 2)
        {
            if (wheelsRight[0].transform.childCount > 0)
            {
                Destroy(wheelsRight[0].transform.GetChild(0).gameObject);
            }
        }

        if (wheelIndex == 3)
        {
            if (wheelsRight[1].transform.childCount > 0)
            {
                Destroy(wheelsRight[1].transform.GetChild(0).gameObject);
            }
        }
    }

    void AddWheel(int wheelIndex, int wheelItemIndex)
    {
        if (wheelIndex == 0)
        {
            if (wheelsLeft[0].transform.childCount < 1)
            {
                GameObject wheelRL = Instantiate(wheelInventory[wheelItemIndex], wheelsLeft[0].transform.position, wheelsLeft[0].transform.rotation, wheelsLeft[0].transform);
            }
            else
            {
                print("no");
            }
        }

        if (wheelIndex == 1)
        {
            if (wheelsLeft[1].transform.childCount < 1)
            {
                GameObject wheelFL = Instantiate(wheelInventory[wheelItemIndex], wheelsLeft[1].transform.position, wheelsLeft[1].transform.rotation, wheelsLeft[1].transform);
            }
            else
            {
                print("no");
            }
        }

        if (wheelIndex == 2)
        {
            if (wheelsRight[0].transform.childCount < 1)
            {
                GameObject wheelRR = Instantiate(wheelInventory[wheelItemIndex], wheelsRight[0].transform.position, wheelsRight[0].transform.rotation, wheelsRight[0].transform);
            }
            else
            {
                print("no");
            }
        }

        if (wheelIndex == 3)
        {
            if (wheelsRight[1].transform.childCount < 1)
            {
                GameObject wheelFR = Instantiate(wheelInventory[wheelItemIndex], wheelsRight[1].transform.position, wheelsRight[1].transform.rotation, wheelsRight[1].transform);
            }
            else
            {
                print("no");
            }
        }
    }
}
