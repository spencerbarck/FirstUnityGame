using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool _isPaused = false;
    public GameObject _pauseMenuUI;

    public Animator _animator;

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

    public void Menu()
    {
        //_pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //_isPaused=false;
        StartCoroutine(LoadLevel(0));
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
    

    IEnumerator LoadLevel(int levelIndex)
    {
        _animator.SetTrigger("LevelOver");
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
