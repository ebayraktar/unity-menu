using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Slider volumeSlider;
    public float volume;
    
    public Dropdown qualityDropDown;
    public int qualityIndex;

    public Toggle toggle1,toggle2,toggleMusic;
    public bool mute;

    private readonly float minVol = -50;
    //private readonly float maxVol = 0;



    private void Start()
    {
        if (FindObjectOfType<AudioManager>().themeMute)
            toggleMusic.isOn = true;

        audioMixer.GetFloat("volume", out volume);
        volumeSlider.value = volume;

        qualityIndex = QualitySettings.GetQualityLevel();
        qualityDropDown.value = qualityIndex;

    }

    public void SetVolume(float _volume)
    {
        if (_volume == minVol)
        {
            float v = -80;
            volumeSlider.value = v;
            audioMixer.SetFloat("volume", v);

            toggle1.isOn = true;
            toggle2.isOn = true;
        }
        else
        {
            volume = _volume;
            volumeSlider.value = volume;
            audioMixer.SetFloat("volume", volume);

            toggle1.isOn = false;
            toggle2.isOn = false;
        }

        
    }

    public void SetQuality(int _qualityIndex)
    {
        qualityIndex = _qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Mute(bool _mute)
    {
        mute = _mute;
        if (mute)
        {
            toggle1.isOn = true;
            toggle2.isOn = true;
            SetVolume(minVol);
        }
        else
        {
            toggle1.isOn = false;
            toggle2.isOn = false;
            if (volume == minVol)
                volume = minVol + 1;
            SetVolume(volume);
        }
    }
    public void Music(bool _music)
    {
        if (_music)
        {
            FindObjectOfType<AudioManager>().Mute("Theme");
        }
        else
        {
            FindObjectOfType<AudioManager>().UnMute("Theme");
        }
    }
}
