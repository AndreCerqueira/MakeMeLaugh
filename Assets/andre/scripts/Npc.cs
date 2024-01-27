using System;
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
            ShowDialog();

            int keyPressed = int.Parse(Input.inputString);

            Inventory playerInventory = player.GetComponent<Inventory>();

            Debug.Log("Player pressed " + keyPressed);

            try
            {
                // Check if the inventory is not null and has enough items

                Item item = playerInventory.items[keyPressed - 1];
                bool isItemGoodForNpc = item.npcIdTarget == id;

                if (isItemGoodForNpc)
                {
                    Debug.Log("Player gave up item");
                    GaveUpItem(keyPressed, playerInventory);
                    // Additional logic for accepting the item

                    // Get all quest components in the scene
                    Quest[] quests = FindObjectsOfType<Quest>();
                    foreach (Quest quest in quests)
                    {
                        if (quest.npcIdTarget == id)
                            quest.MarkAsCheck();
                    }

                    int questsCount = quests.Length;
                    int questsCompleted = 0;
                    foreach (Quest quest in quests)
                    {
                        if (quest.IsQuestCompleted())
                            questsCompleted++;
                    }

                    // Check if all quests are completed
                    if (questsCompleted == questsCount)
                    {
                        Debug.Log("All quests completed");
                        GameManager gameManager = FindObjectOfType<GameManager>();
                        gameManager.ShowWinPopUp();
                    }

                }
                else
                {
                    Debug.Log("Not good");
                }

            }
            catch (Exception)
            {

            }
            
        }

    }


    public void ShowDialog()
    {
        // 
    }


    public void GaveUpItem(int index, Inventory inventory)
    {
        // Destruir o item na lista e visualmente
        inventory.slots[index - 1].transform.Find("Item").gameObject.SetActive(false);
        inventory.items[index - 1] = null;

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
