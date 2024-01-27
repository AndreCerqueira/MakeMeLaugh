using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject[] npcs;

    // Start is called before the first frame update
    void Start()
    {
        // instancia os npcs em posições aleatórias
        foreach (GameObject npc in npcs)
        {
            // cria o npc
            // GameObject npcInstance = 
            Instantiate(npc, npc.GetComponent<Npc>().position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
