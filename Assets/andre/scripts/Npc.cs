using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public int id;
    public GameObject prefab;
    public Vector3 position;

    // private bool isItemGoodForNpc = false;
    private bool isPlayerInRange = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)))
        {
            int keyPressed = int.Parse(Input.inputString);

            Inventory playerInventory = player.GetComponent<Inventory>();

            Debug.Log("Player pressed " + keyPressed);

            try
            {
                // Check if the inventory is not null and has enough items
                if (playerInventory != null && playerInventory.items.Count >= keyPressed)
                {
                    int index = 0;
                    foreach (var item in playerInventory.items)
                    {
                        index++;
                        if (index != keyPressed) return;

                        bool isItemGoodForNpc = item.npcIdTarget == id;

                        if (isItemGoodForNpc)
                        {
                            Debug.Log("Player gave up item");
                            GaveUpItem(index, playerInventory);
                            // Additional logic for accepting the item
                        }
                        else
                        {
                            Debug.Log("Not good");
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }

    }


    public void GaveUpItem(int index, Inventory inventory)
    {
        // Destruir o item na lista e visualmente
        inventory.slots[index - 1].transform.Find("Item").gameObject.SetActive(false);
        inventory.items.RemoveAt(index - 1);

        // check da missao do npc
    }



    // On Trigger enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
            player = collision.gameObject;
        }
    }

    // On Trigger exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
            player = null;
        }
    }
}
