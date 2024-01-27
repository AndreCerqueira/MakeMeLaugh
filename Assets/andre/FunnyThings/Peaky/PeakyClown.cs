using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeakyClown : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // random in 1 to 4
        int random = Random.Range(1, 4);

        switch (random)
        {
            case 1:
                transform.position = new Vector3(916f, -686f, 0);
                transform.rotation = Quaternion.Euler(0, 0, 37.694f);
                animator.SetTrigger("do1");
                break;
            case 2:
                transform.position = new Vector3(-1042f, -689f, 0); 
                transform.rotation = Quaternion.Euler(0, 180, 37.694f);
                animator.SetTrigger("do2");
                break;
            case 3:
                transform.position = new Vector3(874f, 639f, 0);
                transform.rotation = Quaternion.Euler(0, 180, 37.694f);
                animator.SetTrigger("do3");
                break;
        }   
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }


    public void ShowImage()
    {
        GetComponent<Image>().enabled = true;
    }
}
