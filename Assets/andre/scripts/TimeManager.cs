using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // TEXT MESH PRO TEXT GUI OBJECT
    public TextMeshProUGUI text;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;


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

    bool isCounting = true;
    // Corroutine to update the counter start at 00:00
    IEnumerator UpdateCounter()
    {
        // Create a new time span
        System.TimeSpan time = new System.TimeSpan(0, 0, 0);
        // While the game is running
        while (isCounting)
        {
            // Add one second to the time
            time = time.Add(new System.TimeSpan(0, 0, 1));
            // Update the text
            text.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
            // Wait one second
            yield return new WaitForSeconds(1);
        }
    }


    public void StopCounter()
    {
        isCounting = false;
    }


    public void UpdateTimes()
    {
        currentTimeText.text = "<color=#B3B5C7><size=65%>Current Time</size></color>\r\n" + text.text;

        if (PlayerPrefs.HasKey("bestTime"))
        {
            string bestTime = PlayerPrefs.GetString("bestTime");
            bestTimeText.text = "<color=#ffef9a><size=65%>Best Time</size></color>\r\n" + bestTime;
            if (bestTime.CompareTo(text.text) > 0)
            {
                PlayerPrefs.SetString("bestTime", text.text);
                bestTimeText.text = "<color=#ffef9a><size=65%>Best Time</size></color>\r\n" + text.text;
            }
        }
        else
        {
            PlayerPrefs.SetString("bestTime", text.text);
            bestTimeText.text = "<color=#ffef9a><size=65%>Best Time</size></color>\r\n" + text.text;
        }
    }

}
