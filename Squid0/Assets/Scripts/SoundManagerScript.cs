using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip _backgroundMusic;
    public static AudioClip _starfishPickupSounds;
    public static AudioClip _pufferfishPickupSounds;
    public static AudioClip _winSounds;
    public static AudioClip _dieSounds;
    public static AudioClip _levelStartSound;
    public static AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _backgroundMusic = Resources.Load<AudioClip> ("Music Space");
        _dieSounds = Resources.Load<AudioClip> ("Death");
        _starfishPickupSounds = Resources.Load<AudioClip> ("StarfishPickup");
        _winSounds = Resources.Load<AudioClip> ("Win");
        _pufferfishPickupSounds = Resources.Load<AudioClip> ("PufferfishPickup");
        _levelStartSound = Resources.Load<AudioClip> ("LevelStart");

        _audioSource = GetComponent<AudioSource> ();
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
            case "Music Space":
                _audioSource.PlayOneShot(_backgroundMusic);
                break;
            case "Death":
                _audioSource.PlayOneShot(_dieSounds);
                break;
            case "StarfishPickup":
                _audioSource.PlayOneShot(_starfishPickupSounds);
                break;
            case "PufferfishPickup":
                _audioSource.PlayOneShot(_pufferfishPickupSounds);
                break;
            case "LevelStart":
                _audioSource.PlayOneShot(_levelStartSound);
                break;
            case "Win":
                _audioSource.PlayOneShot(_winSounds);
                break;
        }
    }
}
