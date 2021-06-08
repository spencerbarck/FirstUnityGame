using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    private Vector2 _initialPosition;
    private Vector2 _currentPosition;
    [SerializeField]
    private bool _isMovingLeft = true;
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
        if((_initialPosition.x==_currentPosition.x)&&(_isMovingLeft))
        {
            _moveDirection=_currentPosition.x - _walkDistance;
        }
        else if((_initialPosition.x==_currentPosition.x)&&(!_isMovingLeft))
        {
            _moveDirection=_currentPosition.x + _walkDistance;
        }
        else if(_initialPosition.x>_currentPosition.x)
        {
            _isMovingLeft = false;
            _moveDirection = _initialPosition.x;
        }
        else if(_initialPosition.x<_currentPosition.x)
        {
            _isMovingLeft = true;
            _moveDirection = _initialPosition.x;
        }

        //perform the move
        transform.position = new Vector2(_moveDirection,transform.position.y);

        _currentPosition=transform.position;
    }
}
