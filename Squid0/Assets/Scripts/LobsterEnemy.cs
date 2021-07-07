using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterEnemy : MonoBehaviour
{
    private Vector2 _initialPosition;
    private Vector2 _currentPosition;
    [SerializeField]
    private bool _isMovingDown = true;
    private float _moveTimer;
    private float _walkDistance = 2.0f;
    private float _walkSpeed = 1.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        _initialPosition = transform.position;
        _currentPosition = _initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _moveTimer+=Time.deltaTime;
        if(_moveTimer>=_walkSpeed)
        {
            CrabWalk();
            _moveTimer=0;
        }
    }

    private void CrabWalk()
    {
        float _moveDirection = 0;
        Vector2 characterScale = transform.localScale;
        if((_initialPosition.y==_currentPosition.y)&&(_isMovingDown))
        {
            _moveDirection=_currentPosition.y - _walkDistance;
        }
        else if((_initialPosition.y==_currentPosition.y)&&(!_isMovingDown))
        {
            _moveDirection=_currentPosition.y + _walkDistance;
        }
        else if(_initialPosition.y>_currentPosition.y)
        {
            _isMovingDown = false;
            _moveDirection = _initialPosition.y;
            characterScale.y = characterScale.y*-1;
        }
        else if(_initialPosition.y<_currentPosition.y)
        {
            _isMovingDown = true;
            _moveDirection = _initialPosition.y;
            characterScale.y = characterScale.y*-1;
        }
        transform.localScale = characterScale;

        //perform the move
        transform.position = new Vector2(transform.position.x,_moveDirection);

        _currentPosition=transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() != null)
        {
            Destroy(gameObject);
        }
    }
}
