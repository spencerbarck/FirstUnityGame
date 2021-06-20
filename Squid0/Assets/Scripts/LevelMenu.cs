using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] public int _levelNumber;
    [SerializeField] public bool _isBoss=false;
    public Animator _animator;
    private TextMeshProUGUI _text;
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if(_isBoss) _text.text = "Boss Level";
        else _text.text ="Level "+_levelNumber;
    }
    public void LoadThisLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + _levelNumber));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _animator.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
