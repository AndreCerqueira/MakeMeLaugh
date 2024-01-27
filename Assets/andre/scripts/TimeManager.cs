using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // TEXT MESH PRO TEXT GUI OBJECT
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine
        StartCoroutine(UpdateCounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Corroutine to update the counter start at 00:00
    IEnumerator UpdateCounter()
    {
        // Create a new time span
        System.TimeSpan time = new System.TimeSpan(0, 0, 0);
        // While the game is running
        while (true)
        {
            // Add one second to the time
            time = time.Add(new System.TimeSpan(0, 0, 1));
            // Update the text
            text.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
            // Wait one second
            yield return new WaitForSeconds(1);
        }
    }

}
