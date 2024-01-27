using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string GetPositiveDialog()
    {
        return "Waku Waku!";
    }

    public string GetNegativeDialog()
    {
        List<string> list = new List<string>
        {
            "I've seen funnier pingo doce bags.",
            "My grandmother is funnier than that, and she's already dead.",
            "Your comedy is more bitter than a shot of vinegar.",
            "If I wanted something that boring, I'd read a phone book.",
            "It was so dry that even the desert got jealous."
        };

        // return random
        return list[Random.Range(0, list.Count)];
    }


    // Fade in and out the speech bubble
    public IEnumerator FadeIn(bool isPositive)
    {
        // use canvasGroup
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        // set text,, get component in child by name Text_Message
        TextMeshProUGUI text = transform.Find("Text_Message").GetComponent<TextMeshProUGUI>();
        text.text = isPositive ? GetPositiveDialog() : GetNegativeDialog();

        // Fade in
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 5;
            yield return null;
        }

    }


    // Fade out the speech bubble
    public IEnumerator FadeOut()
    {
        // use canvasGroup
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        // Fade out
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }

    }

    // Show the speech bubble
    public void Show(bool isPositive)
    {
        StartCoroutine(FadeIn(isPositive));

        // Make so that the speech bubble disappears after 3 seconds
        StartCoroutine(DisappearAfterSeconds(3));
    }

    // Make so that the speech bubble disappears after a certain amount of seconds
    public IEnumerator DisappearAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(FadeOut());
    }

}
