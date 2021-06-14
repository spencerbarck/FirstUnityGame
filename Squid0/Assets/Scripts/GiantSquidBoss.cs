using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSquidBoss : MonoBehaviour
{
    [SerializeField] float _speed = -10;
    float _initialSpeed;
    float _tiltTimer;
    float _tiltTime = 7.75f;
    float _waitAttackTimer;
    float _waitAttackTime = 3f;
    float _tiltSpeed = 0.05f;
    bool _tiltingUp = true;
    bool _atStart = true;
    int _attackCount;
    int _numberOfAttacks = 3;
    Vector3 _initialPosition;
    void Start()
    {
        _initialPosition=transform.position;
        _initialSpeed = _speed;
    }
    void Update()
    {
        //tilt timer count up and stop
        _tiltTimer+=Time.deltaTime;

        if(_tiltTimer<=_tiltTime)
        {
            Tilt();
        }
        else
        {
            if(_waitAttackTimer<=0.01f)
            {
                _atStart=false;
            }

            //attack timer count up and continue
            _waitAttackTimer+=Time.deltaTime;

            if((_atStart==false)&&(transform.rotation.eulerAngles.z!=180))
            {
                FlipClockwisePointLeft();
            }
            //start move after waiting a bit
            if(_waitAttackTimer>_waitAttackTime)
            {
                AttackLeft();
            }
        }
    }

    private void FlipClockwisePointLeft()
    {
        if((transform.rotation.eulerAngles.z<175)||(transform.rotation.eulerAngles.z>185)) transform.Rotate(0,0,0.3f*-1,Space.Self); 
        else transform.eulerAngles = new Vector3(0,0,180.0f);
    }

    private void FlipCounterClockwisePointRight()
    {
        if(transform.rotation.eulerAngles.z>0)
        {
            transform.Rotate(0,0,-0.3f*-1,Space.Self);
        } 
        else transform.eulerAngles = new Vector3(0,0,0);
    }
    private void Tilt()
    {
        //tilting up
        if(_tiltingUp)
        {
            if((transform.rotation.eulerAngles.z>315.0f)||(transform.rotation.eulerAngles.z<180.0f))
            {
                transform.Rotate(0,0,_tiltSpeed*-1,Space.Self); 
            }
            else _tiltingUp=false;
        }
        //tilting down
        else
        {
            if((transform.rotation.eulerAngles.z<45.0f)||(transform.rotation.eulerAngles.z>180.0f))
            {
                transform.Rotate(0,0,_tiltSpeed,Space.Self); 
            }
            else _tiltingUp=true;
        }
        if(_tiltTimer>=_tiltTime)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }

    private void AttackLeft()
    {
        if(!_atStart)
        {
            //left of center
            if (transform.position.x<=0)
            {
                transform.position += new Vector3(Time.deltaTime*_speed,0);
                _speed-=0.05f; //accelerate
            }
            //right of center
            if(transform.position.x>-0)
            {
                transform.position += new Vector3(Time.deltaTime*_speed,0);
                _speed+=0.05f; //deccelerate
                if(_speed>0)_speed=-3.0f;
            }
            //check if off the map
            if(transform.position.x<-30) 
            {
                _attackCount++;
                transform.position=new Vector3(30,0);
            }
            //attack done
            if((transform.position.x<=2)&&(transform.position.x>-2)&&(_attackCount==_numberOfAttacks))
            {
                transform.position=_initialPosition;
                _atStart=true;
            }
        }
        else
        {
            //end attack
            if(transform.rotation.eulerAngles.z==0)
            {
                _speed = _initialSpeed;
                _attackCount=0;
                _waitAttackTimer=0.01f;
                _tiltTimer=0;
            }  
            else 
            {
                FlipCounterClockwisePointRight();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
}
