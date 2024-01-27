using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itens;

    // Start is called before the first frame update
    void Start()
    {

        // instancia os itens em posições aleatórias
        foreach (GameObject item in itens)
        {
            // cria o item
            // GameObject itemInstance = 
            Instantiate(item, item.GetComponent<Item>().GetRandomPosition(), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
