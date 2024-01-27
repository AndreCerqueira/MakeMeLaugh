using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        float posY = Mathf.Clamp(player.position.y, -3.53f, 2.9f);
        this.transform.position = new Vector3(this.transform.position.x, posY, this.transform.position.z);
    }
}
