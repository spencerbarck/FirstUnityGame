using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;

public class LevelControlScript : MonoBehaviour
{
    private static bool _gameOver;
    private StarfishEnemy[] _enemies;
    private PufferFishEnemy[] _pickups;
    private PorcupinePufferEnemy[] _pickups2;
    private SquidPlayer _player;
    public Animator _animator;
    public Text _speedText;
    public Text _starFishText;
    public Text _pufferFishText;
    public Text _winLoseText;
    public Text _finalSpeedText;
    public Text _continueText;
    public Text _levelNumber;
    private bool _winState;
    private bool _loseState;
    private bool _endState;
    private float _levelOverTimer;
    private bool _musicPlaying;
    private int _starFishCount;
    private int _pufferFishCount;
    void OnEnable()
    {
        _enemies = FindObjectsOfType<StarfishEnemy>();
        _starFishCount = _enemies.Length;
        _pickups = FindObjectsOfType<PufferFishEnemy>();
        _pufferFishCount = _pickups.Length;
        _pickups2 = FindObjectsOfType<PorcupinePufferEnemy>();
        _pufferFishCount += _pickups2.Length;

        _player = FindObjectOfType<SquidPlayer>();
        _winLoseText.text = "";
        _finalSpeedText.text = "";

        _levelNumber.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
    void Start()
    {
        
    }
    void Update()
    {
        _speedText.text = "Speed: " + _player.getSpeed()*100;
        if(_musicPlaying==false)
        {
            _musicPlaying=true;
            if(SceneManager.GetActiveScene().buildIndex == 26)SoundManagerScript.PlaySound("Boss Music");
            else
            {
                if(SceneManager.GetActiveScene().buildIndex%2 == 0){  
                    SoundManagerScript.PlaySound("Music Space");
                }else{
                    SoundManagerScript.PlaySound("Music Space 2");
                }
            }
        }

        if(!_endState)
        {
            if (_player == null)
            {
                _endState = true;
                _loseState = true;
            }
            bool hasEnemy = false;
            int localStarfishCount = 0;
            foreach(StarfishEnemy enemy in _enemies)
            {
                if(enemy != null)
                {
                    localStarfishCount++;
                    hasEnemy = true;
                }
            }
            int localPufferFishCount = 0;
            foreach(PufferFishEnemy pickup in _pickups)
            {
                if(pickup != null)
                {
                    localPufferFishCount++;
                }
            }
            foreach(PorcupinePufferEnemy pickup in _pickups2)
            {
                if(pickup != null)
                {
                    localPufferFishCount++;
                }
            }

            if(!hasEnemy)
            {
                _endState = true;
                _winState = true;
            }
            _starFishText.text = localStarfishCount+"/"+_starFishCount;
            _pufferFishText.text = localPufferFishCount+"/"+_pufferFishCount;
        }

        if(_winState && _levelOverTimer==0)
        {
            Debug.Log("You win");
            SoundManagerScript.PlaySound("Win");
            _finalSpeedText.text = "Final Speed: " + _player.getSpeed()*100;
            _continueText.text = "Press Space To Continue";
            _winLoseText.text = "Squid Wins";
            _player.HaltSquidForWin();
        }

        if(_loseState && _levelOverTimer==0)
        {
            Debug.Log("You lose");
            SoundManagerScript.PlaySound("Death");
            _finalSpeedText.text = "Final Speed: " + _player.getSpeed()*100;
            _continueText.text = "Press Space To Restart";
            _winLoseText.text = "Squid Loses";
        }

        if(_endState)
        {
            _levelOverTimer+=Time.deltaTime;
        }

        //if((_levelOverTimer>2)&& _loseState)
        if(_loseState)
        {
            if(InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)LoadThisLevel();
        }//else if((_levelOverTimer>2)&& _winState)
        else if(_winState)
        {
            if(InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        if(SaveSystem.LoadPlayer().level<SceneManager.GetActiveScene().buildIndex+1)
        SaveSystem.SavePlayer(SceneManager.GetActiveScene().buildIndex+1);

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadThisLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _animator.SetTrigger("LevelOver");
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
