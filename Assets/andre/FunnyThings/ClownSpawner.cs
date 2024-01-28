using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownSpawner : MonoBehaviour
{
    public GameObject[] clowns;
    public static bool bananaInScene = false;

    // Start is called before the first frame update
    void Start()
    {
        // start coroutine
        StartCoroutine(SpawnClown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // corroutine spawn clown every 10 seconds
    IEnumerator SpawnClown()
    {
        Debug.Log("SpawnClown");

        while (true)
        {

            // wait 10 seconds
            yield return new WaitForSeconds(3);

            GameObject clown = null;

            if (bananaInScene)
            {
                clown = Instantiate(clowns[Random.Range(1, clowns.Length)], transform.position, Quaternion.identity);
            }
            else
            {
                clown = Instantiate(clowns[Random.Range(0, clowns.Length)], transform.position, Quaternion.identity);
            }

            // check if has peaky in name and summon more 2 of them
            if (clown.name.ToLower().Contains("peaky"))
            {
                Instantiate(clowns[1], transform.position, Quaternion.identity);
                Instantiate(clowns[1], transform.position, Quaternion.identity);
            }

            // set scale to 1
            clown.transform.localScale = new Vector3(1, 1, 1);

            // get Clowns container with Find
            GameObject clownsContainer = GameObject.Find("Clowns");
            clown.transform.SetParent(clownsContainer.transform);
            clown.transform.localScale = new Vector3(2, 2, 2);

            if (clown.name.ToLower().Contains("rolling"))
            {
                clown.transform.localScale = new Vector3(3, 3, 3);
            }

                // add 100 in x offset if banana or tomate clown
            if (clown.name.ToLower().Contains("banana"))
            {
                clown.transform.localScale = new Vector3(1, 1, 1);
                clown.transform.position = new Vector3(clown.transform.position.x + 100, clown.transform.position.y, clown.transform.position.z);
                bananaInScene = true;
            }

            if (clown.name.ToLower().Contains("tomate"))
            {
                clown.transform.localScale = new Vector3(3, 3, 3);
                clown.transform.position = new Vector3(clown.transform.position.x + Random.Range(200, 500), clown.transform.position.y, clown.transform.position.z);
            }

            // play sound
            SoundManager.instance.PlayRandomSoundEffect();

        }
    }
}
