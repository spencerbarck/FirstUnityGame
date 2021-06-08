using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaObject : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField] float _speed = -2;
    void Start()
    {
        if(transform.localScale.x<0) _speed = _speed*-1;
    }
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime*_speed,0);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _speed = _speed * -1;

        Vector2 characterScale = transform.localScale;
        characterScale.x = characterScale.x*-1;
        transform.localScale = characterScale;


    }
}
