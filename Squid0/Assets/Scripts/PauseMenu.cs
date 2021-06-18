using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool _isPaused = false;
    public GameObject _pauseMenuUI;

    void Update()
    {
        if(InputSystem.GetDevice<Keyboard>().escapeKey.wasPressedThisFrame)
        {
            if(_isPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused=false;
    }
    
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused=true;
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
