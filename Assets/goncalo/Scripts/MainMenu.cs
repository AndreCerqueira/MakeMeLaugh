using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject ScnChanger;
    public GameObject menuSom;
    public float totalTimeToDarken = 7f;
    public AudioClip audioClip;

    private float startTime;
    private float targetAlpha = 1f;
    private AudioSource audioSource;


    void Start()
    {
        SetAlpha(0f);
        startTime = Time.time; // Record the start time
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    public void GoToScene(string sceneName)
    {
        ScnChanger.SetActive(true);
        StartCoroutine(ChangeAlphaGradually(sceneName));
        Debug.Log("Started changing alpha gradually");
        
    }

    // Coroutine to gradually change the alpha value
    private System.Collections.IEnumerator ChangeAlphaGradually(string sceneName)
    {
        while (ScnChanger.GetComponent<Image>().color.a < targetAlpha)
        {
            ChangeAlpha();
            yield return null;
        }

        Debug.Log("Alpha reached the target, loading scene");

        audioSource.Play();
        textObject.gameObject.SetActive(true);
        StartCoroutine(WriteText());

        yield return new WaitForSeconds(audioClip.length + 1f); // 1 second buffer

        Debug.Log("Audio finished, loading scene");
        // Once the audio has finished, load the scene
        SceneManager.LoadScene(sceneName);
    }



    public TextMeshProUGUI textObject;
    // corroutine writing text on screen
    IEnumerator WriteText()
    {
        string text = "Ladies and gentleman's. Boys and Girls. It has arrived. Come!";
        
        foreach (char c in text.ToCharArray()) 
        {
            textObject.text += c;
            yield return new WaitForSeconds(0.075f);
        }
    }


    void ChangeAlpha()
    {
        // Calculate the normalized time elapsed
        float normalizedTime = (Time.time - startTime) / totalTimeToDarken;

        float newAlpha = Mathf.Lerp(0f, targetAlpha, normalizedTime);

        // Set the new alpha value
        SetAlpha(newAlpha);
    }

    void SetAlpha(float alphaValue)
    {
        // Get the current color
        Color currentColor = ScnChanger.GetComponent<Image>().color;

        // Set the alpha value
        currentColor.a = alphaValue;

        // Set the new color
        ScnChanger.GetComponent<Image>().color = currentColor;
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }

    public void AbrirSom()
    {
        menuSom.SetActive(true);
    }

    public void FecharSom()
    {
        menuSom.SetActive(false);
    }
}
