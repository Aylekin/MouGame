using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    public Slider musicSlider;
    public Slider odglosySlider;
    public Toggle TogMusic;
    public Toggle TogOdglosy;

    public void MusicToggle(bool newValue)
    {
        musicSlider.value = -60;
        musicSlider.interactable = newValue;
    }

    public void OdglosyToggle(bool newValue)
    {
        odglosySlider.value = -60;              //bo -60 to najmniejsza wartość suwaka
        odglosySlider.interactable = newValue; //suwak aktywny/nieaktywny
    }

    //zapisanie ustawień
    private void Start()
    {
        if (PlayerPrefs.HasKey("select"))
        {
            if (PlayerPrefs.GetInt("select") == 1)
            {
                TogMusic.isOn = true;
            }
            else
            {
                TogMusic.isOn = false;
            }
        }

        if (PlayerPrefs.HasKey("select1"))
        {
            if (PlayerPrefs.GetInt("select1") == 1)
            {
                TogOdglosy.isOn = true;
            }
            else
            {
                TogOdglosy.isOn = false;
            }
        }
    }

    private void Update()
    {
        if (TogMusic.isOn == true)
        {
            PlayerPrefs.SetInt("select", 1);
        }
        else
        {
            PlayerPrefs.SetInt("select", 0);
        }

        if (TogOdglosy.isOn == true)
        {
            PlayerPrefs.SetInt("select1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("select1", 0);
        }
    }
}
