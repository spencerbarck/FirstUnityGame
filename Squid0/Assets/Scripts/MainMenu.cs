using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator _animator;
    private bool _musicPlaying = false;

    void Update()
    {
        if(!_musicPlaying)
        {
            if(SceneManager.GetActiveScene().buildIndex==36)SoundManagerScript.PlaySound("End Music");
            else SoundManagerScript.PlaySound("Menu Music");
            _musicPlaying=true;
        }
    }
    public void PlayGame()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMenuLevel()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _animator.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
