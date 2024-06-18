using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] float maxRangeVolume = 20f;

    private void Start()
    {
        SetMasterVolume(PlayerPrefs.GetFloat("SavedMasterVolume", PreferenceKeys.default_master_volume));
        SetMusicVolume(PlayerPrefs.GetFloat("SavedMusicVolume", PreferenceKeys.default_music_volume));
        SetSFXVolume(PlayerPrefs.GetFloat("SavedSFXVolume", PreferenceKeys.default_sfx_volume));
    }

    public void SetMasterVolume(float volume)
    {
        RefreshSlider(masterVolumeSlider, volume);
        volume = Mathf.Epsilon + volume * (1.0f - Mathf.Epsilon);
        PlayerPrefs.SetFloat("SavedMasterVolume", volume);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * maxRangeVolume);
    }

    public void SetMusicVolume(float volume)
    {
        RefreshSlider(musicVolumeSlider, volume);
        volume = Mathf.Epsilon + volume * (1.0f - Mathf.Epsilon);
        PlayerPrefs.SetFloat("SavedMusicVolume", volume);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * maxRangeVolume);
    }

    public void SetSFXVolume(float volume)
    {
        RefreshSlider(sfxVolumeSlider, volume);
        volume = Mathf.Epsilon + volume * (1.0f - Mathf.Epsilon);
        PlayerPrefs.SetFloat("SavedSFXVolume", volume);
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * maxRangeVolume);
    }

    public void SetMasterVolumefromSlider()
    {
        SetMasterVolume(masterVolumeSlider.value);
    }

    public void SetMusicVolumeFromSlider()
    {
        SetMusicVolume(musicVolumeSlider.value);
    }

    public void SetSFXVolumeFromSlider()
    {
        SetSFXVolume(sfxVolumeSlider.value);
    }

    public void RefreshSlider(Slider slider, float value)
    {
        slider.value = value;
    }

    //private void OnDestroy()
    //{
    //    PlayerPrefs.SetFloat("SavedMasterVolume", 1.0f);
    //    PlayerPrefs.SetFloat("SavedMusicVolume", 0.5f);
    //    PlayerPrefs.SetFloat("SavedSFXVolume", 0.5f);
    //}
}

