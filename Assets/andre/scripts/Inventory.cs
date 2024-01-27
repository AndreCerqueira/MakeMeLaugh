using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        items = new Item[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        // look for the first empty slot
        int index = 0;
        foreach (var slot in slots)
        {
            if (slot.transform.Find("Item").gameObject.activeSelf)
            {
                index++;
                continue;
            }
            // Add item to the slot
            slot.transform.Find("Item").gameObject.SetActive(true);
            slot.transform.Find("Item").GetComponent<Image>().sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
            // Add item to the inventory
            items[index] = item;
            break;
        }
    }




}
