using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject winPopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWinPopUp()
    {
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        timeManager.StopCounter();
        timeManager.UpdateTimes();

        winPopup.SetActive(true);
    }
}
