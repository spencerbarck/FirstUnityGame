using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSquidBoss : MonoBehaviour
{

    //timer variables
    float _tiltTimer;
    float _tiltTime = 7.75f;
    float _waitAttackTimer;
    float _waitAttackTime = 3f;
    float _rotateStopTimer = 0.25f;
    float _rotateStopTime = 0.25f;
    //end timer variables

    //speed variables
    [SerializeField] float _speed = -10;
    float _initialSpeed;
    float _tiltSpeed = 0.05f;
    //end speed variables

    //movement variables
    bool _tiltingUp = false;
    bool _pointingUp;
    bool _swayingLeft;
    Vector3 _initialPosition;

    int _rotateQuarter=0;
    //end movement variables

    //attack variables
    int _attackCount;
    int _numberOfAttacks = 3; //number of attacks per attack type (SmallTiltLeftAttack strikes left x times)
    int _randomAttack;
    bool _attackChosen = false;
    bool _firstAttackDone;//used to make sure the first attack is SmallTiltLeftAttack
    bool _tenticlesExtended;
    int _lastAttack;
    //end attack variables
    public Animator _squidAnimator;
    public PolygonCollider2D _squidColliderTenticlesUp;
    public PolygonCollider2D _squidColliderTenticlesDown;

    bool _atStart = true;
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
            _randomAttack=_lastAttack;
            while(_randomAttack==_lastAttack)
            {
                _randomAttack = Random.Range(1, 4);
            }
            _attackChosen=true;
            if(!_firstAttackDone)
            {
                _randomAttack=1;
                _firstAttackDone=true;
            }
            _lastAttack = _randomAttack;
        }
        switch(_randomAttack){
            case 1:
                SmallTiltLeftAttack();
                break;
            case 2:
                LargeTiltUpAttack();
                break;
            case 3:
                SpinTenticleAttack();
                break;
        }
    }

    private void SpinTenticleAttack()
    {
        if(_waitAttackTimer<=0.01f)
        {
            _tenticlesExtended = true;
            _squidAnimator.SetBool("TenticlesExtended",true);
            _squidColliderTenticlesDown.enabled=true;
            _squidColliderTenticlesUp.enabled=false;
            _atStart=false;
        }
        _waitAttackTimer+=Time.deltaTime;

        if(_waitAttackTimer>_waitAttackTime)
        {
                FullSpin();
        }
    }

    private void FullSpin()
    {
        if(!_atStart)
        {
            if(_rotateStopTimer<_rotateStopTime)
            {
                _rotateStopTimer+=Time.deltaTime;
            }
            else
            {
                if(_rotateQuarter==0)
                {
                    if((transform.rotation.eulerAngles.z>315.0f)||(transform.rotation.eulerAngles.z<=45f))
                    {
                        transform.Rotate(0,0,0.15f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==1)
                {
                    if((transform.rotation.eulerAngles.z>225.0f))
                    {
                        transform.Rotate(0,0,0.15f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==2)
                {
                    if((transform.rotation.eulerAngles.z>135.0f))
                    {
                        transform.Rotate(0,0,0.15f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==3)
                {
                    if((transform.rotation.eulerAngles.z>45.0f))
                    {
                        transform.Rotate(0,0,0.15f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==4)
                {
                    if(_attackCount>=_numberOfAttacks-1) 
                    {
                        if(transform.rotation.eulerAngles.z<=45f)
                        {
                            transform.Rotate(0,0,0.15f*-1,Space.Self); 
                        }
                        else _atStart=true;
                    }
                    else
                    {
                        _rotateQuarter=0;
                        _attackCount++;
                    }
                }       
            }
        }
        else
        {
            transform.eulerAngles = new Vector3(0,0,0);
            _tenticlesExtended = false;
            _squidAnimator.SetBool("TenticlesExtended",false);
            _squidColliderTenticlesDown.enabled=false;
            _squidColliderTenticlesUp.enabled=true;
            
            _attackCount=0;
            _waitAttackTimer=0.01f;
            _attackChosen=false;
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
                if(_attackCount==1) randAttack=1;
                if(_attackCount==2) randAttack=3;
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
        if(collision.collider.GetComponent<SquidPlayer>() == null)
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
}
