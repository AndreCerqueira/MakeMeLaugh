using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // array of sound effects
    public AudioClip[] soundEffects;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // play random sound effect
    public void PlayRandomSoundEffect()
    {
        // get random sound effect
        AudioClip soundEffect = soundEffects[Random.Range(0, soundEffects.Length)];
        // play sound effect
        GetComponent<AudioSource>().PlayOneShot(soundEffect);
    }
}
