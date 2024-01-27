using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        // Add item to the list
        items.Add(item);

        int index = items.IndexOf(item);

        Debug.Log("SetActive");

        // Add item to the slot
        slots[index].transform.Find("Item").gameObject.SetActive(true);
        slots[index].transform.Find("Item").GetComponent<Image>().sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;

    }




}
