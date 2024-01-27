using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public int npcIdTarget;
    public GameObject check;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MarkAsCheck()
    {
        check.SetActive(true);
    }

    public bool IsQuestCompleted()
    {
        return check.activeSelf;
    }
}
