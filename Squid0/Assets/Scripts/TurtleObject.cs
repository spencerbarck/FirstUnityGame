using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleObject : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField] float _speed = -2;
    [SerializeField] bool _upAndDown = false;
    void Start()
    {
        if(transform.localScale.x<0) _speed = _speed*-1;
    }
    void Update()
    {
        if(_upAndDown) transform.position += new Vector3(0,Time.deltaTime*_speed);   
        else transform.position += new Vector3(Time.deltaTime*_speed,0);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<BoarderObject>() != null)
        {
            _speed = _speed * -1;
            Vector2 characterScale = transform.localScale;
            if(_upAndDown) characterScale.y = characterScale.y*-1;
            else characterScale.x = characterScale.x*-1;
            transform.localScale = characterScale;
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        
    }
}
