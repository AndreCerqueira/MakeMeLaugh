using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider MasterSlider;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_MASTER = "MasterVolume";

    void Awake()
    {
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
        MasterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 0.5f);
        MasterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, 0.5f);

    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, MusicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, MasterSlider.value);

    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }
}
