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
        while (Time.time - startTime < totalTimeToDarken)
        {
            ChangeAlpha();
            Debug.Log("Changed alpha: " + ScnChanger.GetComponent<Image>().color.a);
            yield return null;
        }

        Debug.Log("Alpha reached the target, loading scene");

        audioSource.Play();

        yield return new WaitForSeconds(audioClip.length + 1f); // 1 second buffer

        Debug.Log("Audio finished, loading scene");
        // Once the audio has finished, load the scene
        SceneManager.LoadScene(sceneName);
    }

    void ChangeAlpha()
    {
        // Calculate the normalized time elapsed
        float normalizedTime = (Time.time - startTime) / totalTimeToDarken;

        // Use Mathf.Lerp to smoothly interpolate between the current alpha and the target alpha
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
