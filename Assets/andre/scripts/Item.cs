using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject prefab;
    public Npc npcTarget;
    public Vector3[] PossibleSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get a random position from the array
    public Vector3 GetRandomPosition()
    {
        return PossibleSpawnPosition[Random.Range(0, PossibleSpawnPosition.Length)];
    }
}
