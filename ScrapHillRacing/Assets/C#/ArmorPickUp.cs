using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    public GameObject[] scrapInventory = new GameObject[6];

    public GameObject armorSlot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            if (armorSlot.transform.childCount > 0)
            {
                Destroy(armorSlot.transform.GetChild(0).gameObject);
            }

            int rand = Random.Range(0, 6);

            GameObject armorScrap = Instantiate(scrapInventory[rand], armorSlot.transform.position, armorSlot.transform.rotation, armorSlot.transform);

            Destroy(other.gameObject);
        }
    }
}
