using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer _audioMixer;
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); 
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
