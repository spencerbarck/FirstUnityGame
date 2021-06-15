using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSquidBoss : MonoBehaviour
{
    [SerializeField] float _speed = -10;
    float _initialSpeed;
    float _tiltTimer;
    float _tiltTime = 7.75f;
    [SerializeField] float _waitAttackTimer;
    float _waitAttackTime = 3f;
    float _tiltSpeed = 0.05f;
    bool _tiltingUp = true;
    bool _pointingUp;
    bool _atStart = true;
    int _attackCount;
    [SerializeField] int _numberOfAttacks = 3;
    Vector3 _initialPosition;
    bool _attackChosen = false;
    int _randomAttack;
    bool _swayingLeft;
    bool _firstAttackDone;
    void Start()
    {
        _initialPosition=transform.position;
        _initialSpeed = _speed;
    }
    void Update()
    {
        //tilt timer count up and stop
        _tiltTimer+=Time.deltaTime;
        if(!_attackChosen)
        {
            _randomAttack = Random.Range(1, 3);
            _attackChosen=true;
            if(!_firstAttackDone)
            {
                _randomAttack=1;
                _firstAttackDone=true;
            }
        }
        switch(_randomAttack){
            case 1:
                SmallTiltLeftAttack();
                break;
            case 2:
                LargeTiltUpAttack();
                break;
        }
    }

    private void LargeTiltUpAttack()
    {
        if(_tiltTimer<=_tiltTime)
        {
            LargeTilt();
        }
        else
        {
            if(_waitAttackTimer<=0.01f)
            {
                transform.eulerAngles = new Vector3(0,0,90.0f);
                _atStart=false;
            }

            _waitAttackTimer+=Time.deltaTime;

            if(_waitAttackTimer>_waitAttackTime)
            {
                AttackUp();
            }
        }
    }

    private void SmallTiltLeftAttack()
    {
        //execute a small 45 degree tilt before attack
        if(_tiltTimer<=_tiltTime)
        {
            SmallTilt();
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
    private void SmallTilt()
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

    private void LargeTilt()
    {
        if(!_pointingUp)
        {
            if(transform.rotation.eulerAngles.z<90.0f)
            {
                transform.Rotate(0,0,0.1f,Space.Self); 
            }
            else
            {
                _pointingUp=true;
            }
        }
        else
        {
            if((transform.rotation.eulerAngles.z<112.5f)&&_tiltingUp)
            {
                transform.Rotate(0,0,0.0575f,Space.Self);
            }
            if((transform.rotation.eulerAngles.z>67.5f)&&!_tiltingUp)
            {
                transform.Rotate(0,0,0.0575f*-1,Space.Self); 
            }
            if(transform.rotation.eulerAngles.z>=112.5f)_tiltingUp=false;
            if(transform.rotation.eulerAngles.z<=67.5f)_tiltingUp=true;
        }
        if(_tiltTimer>=_tiltTime)
        {
            transform.eulerAngles = new Vector3(0,0,90.0f);
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
                //random attacks in the three lanes
                int randAttack = Random.Range(1, 4);
                if(_attackCount==_numberOfAttacks) randAttack=2;
                switch(randAttack){
                    case 1:
                        transform.position=new Vector3(30,_initialPosition.y+6);
                        break;
                    case 2:
                        transform.position=new Vector3(30,_initialPosition.y);
                        break;
                    case 3:
                        transform.position=new Vector3(30,_initialPosition.y-6);
                        break;
                    default:
                        break;
                }
                //transform.position=new Vector3(30,transform.position.y);
            }
            //attack done
            if((transform.position.x<=2)&&(transform.position.x>-2)&&(_attackCount==_numberOfAttacks))
            {
                transform.position=new Vector3(_initialPosition.x,transform.position.y);
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
                _attackChosen=false;
            }  
            else 
            {
                FlipCounterClockwisePointRight();
            }
        }
    }

    private void AttackUp()
    {
        if(!_atStart)
        {
            if(_swayingLeft)
            {
                if(transform.position.x>-5)
                transform.position += new Vector3(Time.deltaTime*-2.25f,0);
                else
                _swayingLeft=false;
            }
            else
            {
                if(transform.position.x<5)
                transform.position += new Vector3(Time.deltaTime*2.25f,0);
                else
                _swayingLeft=true;
            }
            //above center
            if (transform.position.y>=0)
            {
                float upSpeed = _speed*-1;
                transform.position += new Vector3(0,Time.deltaTime*upSpeed);
                _speed-=0.05f; //accelerate
            }
            //below center
            if(transform.position.y<0)
            {
                float upSpeed = _speed*-1;
                transform.position += new Vector3(0,Time.deltaTime*upSpeed);
                _speed+=0.05f; //deccelerate
                if(_speed>0)_speed=-3.0f;
            }
            //check if off the map
            if(transform.position.y>30) 
            {
                _attackCount++;
                transform.position=new Vector3(transform.position.x,-30);
            }
            //attack done
            if((transform.position.y<=2)&&(transform.position.y>-2)&&(_attackCount==_numberOfAttacks))
            {
                transform.position=new Vector3(transform.position.x,_initialPosition.y);
                _atStart=true;
            }
        }
        else
        {
            transform.position = new Vector3(0,0);
            if((transform.rotation.eulerAngles.z>0.0f)&&(transform.rotation.eulerAngles.z<180.0f))
            {
                transform.Rotate(0,0,-0.1f,Space.Self);
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                _speed = _initialSpeed;
                _attackCount=0;
                _waitAttackTimer=0.01f;
                _tiltTimer=0;
                _attackChosen=false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
}
