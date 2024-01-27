using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int npcIdTarget;
    public Vector3[] PossibleSpawnPosition;

    private bool isPlayerInRange = false;
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player picked up item");
            player.GetComponent<Inventory>().AddItem(this);
            Destroy(gameObject);
        }
    }

    // Get a random position from the array
    public Vector3 GetRandomPosition()
    {
        return PossibleSpawnPosition[Random.Range(0, PossibleSpawnPosition.Length)];
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
