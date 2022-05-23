using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider volume;
    public Slider music;
    public Toggle reload;

    private void Start()
    {
        volume.value = PlayerPrefs.GetInt("Volume", 0);
        music.value = PlayerPrefs.GetInt("Music", 0);

        if (PlayerPrefs.GetInt("AutoReload", 1) == 1) reload.isOn = true;
        else reload.isOn = false;
    }

    public void SetVolume(float _volume)
    {
        audioMixer.SetFloat("volume", _volume);
        PlayerPrefs.SetInt("Volume", (int)_volume);
    }
    public void SetMusic(float _music)
    {
        audioMixer.SetFloat("music", _music);
        PlayerPrefs.SetInt("Music", (int)_music);
    }
    public void AutoReload(bool _autoReload)
    {
        if (_autoReload) PlayerPrefs.SetInt("AutoReload", 1);
        else PlayerPrefs.SetInt("AutoReload", 0);
    }
}
