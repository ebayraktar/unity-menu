using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Slider volumeSlider;
    public float volume;

    public Dropdown qualityDropDown;
    public int qualityIndex;

    private readonly float minVol = -50f;

    private void Start()
    {
        audioMixer.GetFloat("volume", out volume);
        volumeSlider.value = volume;
        
        qualityIndex = QualitySettings.GetQualityLevel();
        qualityDropDown.value = qualityIndex;
    }

    public void SetVolume(float _volume)
    {
        float vol = _volume;
        if (_volume == minVol)
            vol = -80;
        audioMixer.SetFloat("volume", vol);
    }

    public void SetQuality(int _qualityIndex)
    {
        QualitySettings.SetQualityLevel(_qualityIndex);
    }
}
