using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaClown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDestroyed()
    {
        ClownSpawner.bananaInScene = false;
        Destroy(gameObject);
    }
}
