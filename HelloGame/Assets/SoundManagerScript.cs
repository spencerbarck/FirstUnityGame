using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip _jumpSound;
    public static AudioClip _groundAttackSound;
    public static AudioClip _diagonalAttackSound;
    public static AudioClip _enlargeSound;
    public static AudioClip _reduceSound;
    public static AudioClip _levelClearSound;
    public static AudioClip _expandSound;
    public static AudioClip _enemyDeadSound;
    public static AudioClip _outOfBoundsSound;
    public static AudioClip _sideFlySound;
    public static AudioClip _slingshotSound;
    public static AudioClip _pullBackSound;
    public static AudioClip _backgroundSound;

    public static AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _jumpSound = Resources.Load<AudioClip> ("jump01");
        _groundAttackSound = Resources.Load<AudioClip> ("GroundAttack");
        _diagonalAttackSound = Resources.Load<AudioClip> ("DiagonalAttack");
        _enlargeSound = Resources.Load<AudioClip> ("Enlarge");
        _reduceSound = Resources.Load<AudioClip> ("Reduce");
        _levelClearSound = Resources.Load<AudioClip> ("LevelClear");
        _expandSound = Resources.Load<AudioClip> ("Expand");
        _enemyDeadSound = Resources.Load<AudioClip> ("EnemyDead");
        _outOfBoundsSound = Resources.Load<AudioClip> ("OutOfBounds");
        _sideFlySound = Resources.Load<AudioClip> ("SideFly");
        _slingshotSound = Resources.Load<AudioClip> ("Slingshot");
        _pullBackSound = Resources.Load<AudioClip> ("PullBack");
        _backgroundSound = Resources.Load<AudioClip> ("Horror1");
        

        _audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
            case "jump":
                _audioSource.PlayOneShot(_jumpSound);
                break;
            case "GroundAttack":
                _audioSource.PlayOneShot(_groundAttackSound);
                break;
            case "DiagonalAttack":
                _audioSource.PlayOneShot(_diagonalAttackSound);
                break;
            case "Enlarge":
                _audioSource.PlayOneShot(_enlargeSound);
                break;
            case "Reduce":
                _audioSource.PlayOneShot(_reduceSound);
                break;
            case "LevelClear":
                _audioSource.PlayOneShot(_levelClearSound);
                break;
            case "Expand":
                _audioSource.PlayOneShot(_expandSound);
                break;
            case "EnemyDead":
                _audioSource.PlayOneShot(_enemyDeadSound);
                break;
            case "OutOfBounds":
                _audioSource.PlayOneShot(_outOfBoundsSound);
                break;
            case "SideFly":
                _audioSource.PlayOneShot(_sideFlySound);
                break;
            case "Slingshot":
                _audioSource.PlayOneShot(_slingshotSound);
                break;
            case "PullBack":
                _audioSource.PlayOneShot(_pullBackSound);
                break;
            case "Background":
                _audioSource.PlayOneShot(_backgroundSound);
                break;
                
        }
    }
}
