using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        // Load the scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene("andre");
    }

    public void Return()
    {
        // Load the scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
