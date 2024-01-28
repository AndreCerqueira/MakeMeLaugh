using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomateClown : MonoBehaviour
{
    public GameObject canvas;
    public GameObject tomatoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowTomato()
    {
        Debug.Log("TOMATO THROWN");

        // Instantiate tomate in canvas

        GameObject tomato = Instantiate(tomatoPrefab);
        tomato.transform.parent = GameObject.Find("tomates").transform;
        tomato.transform.localPosition = new Vector3(90, 49, 0);

        // change position to 90 49

    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}
