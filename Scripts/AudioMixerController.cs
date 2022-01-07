using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Space(10)]
    public Slider musicSlider;
    public Slider odglosySlider;
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetOdglosyVolume(float volume)
    {
        audioMixer.SetFloat("odglosyVolume", volume);
    }

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
        odglosySlider.value = PlayerPrefs.GetFloat("odglosyVolume", 0);
    }

    private void OnDisable()
    {
        float musicVolume = 0;
        float odglosyVolume = 0;

        audioMixer.GetFloat("musicVolume", out musicVolume);
        audioMixer.GetFloat("odglosyVolume", out odglosyVolume);

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("odglosyVolume", odglosyVolume);
        PlayerPrefs.Save();
    }
}
