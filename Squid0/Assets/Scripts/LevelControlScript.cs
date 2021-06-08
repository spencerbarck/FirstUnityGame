using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControlScript : MonoBehaviour
{
    private static bool _gameOver;
    private StarfishEnemy[] _enemies;
    private PufferFishEnemy[] _pickups;
    private SquidPlayer _player;
    public Text _speedText;
    public Text _starFishText;
    public Text _pufferFishText;
    public Text _winLoseText;
    public Text _finalSpeedText;
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

        _player = FindObjectOfType<SquidPlayer>();
        _winLoseText.text = "";
        _finalSpeedText.text = "";
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
            SoundManagerScript.PlaySound("Music Space");
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
            _winLoseText.text = "Squid Wins";
            _player.HaltSquidForWin();
        }

        if(_loseState && _levelOverTimer==0)
        {
            Debug.Log("You lose");
            SoundManagerScript.PlaySound("Death");
            _finalSpeedText.text = "Final Speed: " + _player.getSpeed()*100;
            _winLoseText.text = "Squid Loses";
        }

        if(_endState)
        {
            _levelOverTimer+=Time.deltaTime;
        }

        if((_levelOverTimer>2)&& _loseState)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }else if((_levelOverTimer>2)&& _winState)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
