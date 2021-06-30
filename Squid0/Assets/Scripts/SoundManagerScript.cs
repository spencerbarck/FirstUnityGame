using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip _backgroundMusic;
    public static AudioClip _background2Music;
    public static AudioClip _bossMusic;
    public static AudioClip _menuMusic;
    public static AudioClip _starfishPickupSounds;
    public static AudioClip _pufferfishPickupSounds;
    public static AudioClip _winSounds;
    public static AudioClip _dieSounds;
    public static AudioClip _levelStartSound;
    public static AudioClip _pearlPickupSound;
    public static AudioClip _shrimpPickupSound;
    public static AudioClip _shrinkSound;
    public static AudioClip _giantSquidSideAttackSound;
     public static AudioClip _giantSquidSpinAttackSound;
    public static AudioClip _giantSquidSpinAttackSpinSound;
    public static AudioClip _giantSquidHurtSound;
    public static AudioClip _giantSquidEatSound;
    public static AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _backgroundMusic = Resources.Load<AudioClip> ("Music Space");
        _background2Music = Resources.Load<AudioClip> ("Music Space 2");
        _bossMusic = Resources.Load<AudioClip> ("Boss Music");
        _menuMusic = Resources.Load<AudioClip> ("Menu Music");
        _dieSounds = Resources.Load<AudioClip> ("Death");
        _starfishPickupSounds = Resources.Load<AudioClip> ("StarfishPickup");
        _winSounds = Resources.Load<AudioClip> ("Win");
        _pufferfishPickupSounds = Resources.Load<AudioClip> ("PufferfishPickup");
        _levelStartSound = Resources.Load<AudioClip> ("LevelStart");
        _pearlPickupSound = Resources.Load<AudioClip> ("PearlPickup");
        _shrimpPickupSound = Resources.Load<AudioClip> ("ShrimpPickup");
        _shrinkSound = Resources.Load<AudioClip> ("Shrink");

        _giantSquidSideAttackSound = Resources.Load<AudioClip> ("GiantSquidSideAttack");
        _giantSquidSpinAttackSound = Resources.Load<AudioClip> ("GiantSquidSpinAttack");
        _giantSquidSpinAttackSpinSound = Resources.Load<AudioClip> ("GiantSquidSpinAttackSpin");
        _giantSquidHurtSound = Resources.Load<AudioClip> ("GiantSquidHurt");
        _giantSquidEatSound = Resources.Load<AudioClip> ("GiantSquidEat");

        _audioSource = GetComponent<AudioSource> ();
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
            case "Music Space":
                _audioSource.PlayOneShot(_backgroundMusic);
                break;
            case "Music Space 2":
                _audioSource.PlayOneShot(_background2Music,0.125f);
                break;
            case "Boss Music":
                _audioSource.PlayOneShot(_bossMusic,0.5f);
                break;
            case "Menu Music":
                _audioSource.PlayOneShot(_menuMusic);
                break;
            case "Giant Squid Side":
                _audioSource.PlayOneShot(_giantSquidSideAttackSound,0.5f);
                break;
            case "Giant Squid Spin":
                _audioSource.PlayOneShot(_giantSquidSpinAttackSound);
                break;
            case "Giant Squid Spin Spin":
                _audioSource.PlayOneShot(_giantSquidSpinAttackSpinSound,0.5f);
                break;
            case "Giant Squid Hurt":
                _audioSource.PlayOneShot(_giantSquidHurtSound);
                break;
            case "Giant Squid Eat":
                _audioSource.PlayOneShot(_giantSquidEatSound);
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
            case "PearlPickup":
                _audioSource.PlayOneShot(_pearlPickupSound);
                break;
            case "ShrimpPickup":
                _audioSource.PlayOneShot(_shrimpPickupSound);
                break;
            case "Shrink":
                _audioSource.PlayOneShot(_shrinkSound);
                break;
        }
    }
}
