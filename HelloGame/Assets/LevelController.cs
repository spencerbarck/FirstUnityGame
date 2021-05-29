using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;

    private static bool _gameOver;
    private FlowerMonster[] _enemies;
    private bool _levelOver;
    private float _levelOverTimer;

    private bool _musicPlaying;
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<FlowerMonster>();
    }
    void Update()
    {
        if(_musicPlaying==false)
        {
            SoundManagerScript.PlaySound("Background");
            _musicPlaying=true;
        }
        if(!_levelOver)
        {
            foreach(FlowerMonster enemy in _enemies)
            {
                if(enemy != null)
                {
                    return;
                }

            }
        }
        _levelOver = true;

        if(_levelOver)
        {
            _levelOverTimer+=Time.deltaTime;
        }

        if(_levelOverTimer>4)
        {
            _levelOverTimer+=1;
            Debug.Log("You killed them all!");
            _nextLevelIndex++;
            string nextLevelName = "level" + _nextLevelIndex;
            if(_nextLevelIndex<4)SceneManager.LoadScene(nextLevelName);
            if(!_gameOver)SoundManagerScript.PlaySound("LevelClear");
            _levelOver=false;
            _levelOverTimer=0;
        }

        if(_nextLevelIndex==4) _gameOver=true;
    }
}
