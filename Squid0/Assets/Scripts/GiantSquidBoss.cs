using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiantSquidBoss : MonoBehaviour
{

    //timer variables
    float _tiltTimer;
    float _tiltTime = 7.75f;
    float _waitAttackTimer;
    float _waitAttackTime = 3f;
    float _rotateStopTimer = 0.25f;
    float _rotateStopTime = 0.25f;

    float _tenticleSoundTimer;
    float _tenticleSoundTime = 0.5f;
    float _levelStartTimer;
    float _levelStartTime = 4f;

    float _startWinMusicTimer;
    float _startWinMusicTime = 2.5f;
    bool _winMusicPlaying;
    //end timer variables

    //speed variables
    [SerializeField] float _speed = -5;
    float _initialSpeed;
    float _tiltSpeed = 30f;
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
    bool _tenticlesExtended = true;
    int _lastAttack;
    //end attack variables
    public Animator _squidAnimator;
    public PolygonCollider2D _squidColliderTenticlesUp;
    public PolygonCollider2D _squidColliderTenticlesDown;

    //health variables
    [SerializeField] public int _health = 5;
    private BossHeart[] _hearts;
    float _damageTimer;
    float _damageTime = 0.5f;
    bool _takingDamage;

    bool _isDying;
    public bool _isDead;
    //end health variables
    bool _atStart = true;
    public Text _helpText;

    void OnEnable()
    {
        _hearts = FindObjectsOfType<BossHeart>();
    }
    void Start()
    {
        _initialPosition=transform.position;
        _initialSpeed = _speed;
    }
    void Update()
    {
        _levelStartTimer+=Time.deltaTime;
        if(_levelStartTimer<_levelStartTime) return;
        
        if(!_isDying){
            //tilt timer count up and stop
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
                //else _randomAttack=3;
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

            if(_takingDamage)
            {
                _damageTimer+=Time.deltaTime;
                
                if(_damageTimer<_damageTime)
                {
                    if((_damageTimer<_damageTime/4)||(_damageTimer>(_damageTime/4)*3))
                    {
                        transform.position += new Vector3(0,Time.deltaTime*10);
                        transform.position += new Vector3(Time.deltaTime*10,0);

                        foreach(BossHeart heart in _hearts)
                        {
                            if(heart!= null)
                            {
                                heart.transform.position+= new Vector3(0,Time.deltaTime*1);
                            }
                        }
                    }
                    else 
                    {
                        transform.position += new Vector3(0,Time.deltaTime*-10);
                        transform.position += new Vector3(Time.deltaTime*-10,0);

                        foreach(BossHeart heart in _hearts)
                        {
                            if(heart!= null)
                            {
                                heart.transform.position+= new Vector3(0,Time.deltaTime*-1);
                            }
                        }
                    }
                }
                else
                {
                    _damageTimer=0;
                    _takingDamage=false;
                    _squidAnimator.SetBool("TakingDamage",false);
                }
            }
        }

        if(_isDying)
        {
            DeathRattle();
        }
    }

    private void SpinTenticleAttack()
    {
        if(_waitAttackTimer<=0.01f)
        {
            _squidAnimator.SetBool("TenticlesExtended",true);
            _squidColliderTenticlesDown.enabled=true;
            _squidColliderTenticlesUp.enabled=false;
            _atStart=false;
        }

        if(_tenticleSoundTimer<_tenticleSoundTime)
            {
                _tenticleSoundTimer+=Time.deltaTime;
            }
            else if(_tenticlesExtended)
            {
                SoundManagerScript.PlaySound("Giant Squid Spin");
                _tenticlesExtended = false;
                _tenticleSoundTimer=0;
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
            if(_rotateStopTimer<=_rotateStopTime)
            {
                _rotateStopTimer+=Time.deltaTime;
            }
            else
            {
                if(_rotateQuarter==0)
                {
                    if((transform.rotation.eulerAngles.z>315.0f)||(transform.rotation.eulerAngles.z<=45f))
                    {
                        transform.Rotate(0,0,Time.deltaTime*75f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        SoundManagerScript.PlaySound("Giant Squid Spin Spin");
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==1)
                {
                    if((transform.rotation.eulerAngles.z>225.0f))
                    {
                        transform.Rotate(0,0,Time.deltaTime*75f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        SoundManagerScript.PlaySound("Giant Squid Spin Spin");
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==2)
                {
                    if((transform.rotation.eulerAngles.z>135.0f))
                    {
                        transform.Rotate(0,0,Time.deltaTime*75f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        SoundManagerScript.PlaySound("Giant Squid Spin Spin");
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==3)
                {
                    if((transform.rotation.eulerAngles.z>45.0f))
                    {
                        transform.Rotate(0,0,Time.deltaTime*75f*-1,Space.Self); 
                    }
                    else
                    {
                        _rotateQuarter++;
                        SoundManagerScript.PlaySound("Giant Squid Spin Spin");
                        _rotateStopTimer = 0;
                    }
                }
                if(_rotateQuarter==4)
                {
                    if(_attackCount>=_numberOfAttacks-1) 
                    {
                        if(transform.rotation.eulerAngles.z<=45f)
                        {
                            transform.Rotate(0,0,Time.deltaTime*75f*-1,Space.Self); 
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
            _tenticlesExtended = true;
            _attackChosen=false;
        }
    }

    private void LargeTiltUpAttack()
    {
        _tiltTimer+=Time.deltaTime;
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
        _tiltTimer+=Time.deltaTime;
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
        if((transform.rotation.eulerAngles.z<175)||(transform.rotation.eulerAngles.z>185)) transform.Rotate(0,0,Time.deltaTime*75f*-1,Space.Self); 
        else transform.eulerAngles = new Vector3(0,0,180.0f);
    }

    private void FlipCounterClockwisePointRight()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
        if(transform.rotation.eulerAngles.z>30)
        {
            transform.Rotate(0,0,Time.deltaTime*-75f*-1,Space.Self);
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
                transform.Rotate(0,0,Time.deltaTime*_tiltSpeed*-1,Space.Self); 
            }
            else _tiltingUp=false;
        }
        //tilting down
        else
        {
            if((transform.rotation.eulerAngles.z<45.0f)||(transform.rotation.eulerAngles.z>180.0f))
            {
                transform.Rotate(0,0,Time.deltaTime*_tiltSpeed,Space.Self); 
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
                transform.Rotate(0,0,Time.deltaTime*30f,Space.Self); 
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
                transform.Rotate(0,0,Time.deltaTime*30f,Space.Self);
            }
            if((transform.rotation.eulerAngles.z>67.5f)&&!_tiltingUp)
            {
                transform.Rotate(0,0,Time.deltaTime*30f*-1,Space.Self); 
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
            if ((transform.position.x==0)&&(_attackCount==0)) SoundManagerScript.PlaySound("Giant Squid Side");
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
                if(_attackCount!=_numberOfAttacks)SoundManagerScript.PlaySound("Giant Squid Side");
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
            if ((transform.position.y==0)&&(_attackCount==0)) SoundManagerScript.PlaySound("Giant Squid Side");
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
                if(_attackCount!=_numberOfAttacks)SoundManagerScript.PlaySound("Giant Squid Side");
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
                transform.Rotate(0,0,Time.deltaTime*75*-1f,Space.Self);
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
    public void ReduceHealth()
    {
        _takingDamage=true;
        _tenticlesExtended=false;
        _squidAnimator.SetBool("TakingDamage",true);
        _health--;
        int highestHeart = -1;
        foreach(BossHeart heart in _hearts)
        {
            if((heart._heartPosition>highestHeart)&&(heart!= null))
            {
                highestHeart=heart._heartPosition;
            }
        }

        foreach(BossHeart heart in _hearts)
        {
            if(heart._heartPosition==highestHeart)
            {
                Destroy(heart.gameObject);
            }
        }

        if(_health<1)
        {
            _isDying=true;
            SoundManagerScript.PlaySound("StopStart");
            //SoundManagerScript.PlaySound("WinGame");
            SoundManagerScript.PlaySound("Giant Squid Dying");
        }
    }

    public void DeathRattle()
    {
        _startWinMusicTimer+=Time.deltaTime;
        if(_startWinMusicTimer>_startWinMusicTime)
        {
            if(!_winMusicPlaying)
            {
                SoundManagerScript.PlaySound("WinGame");
                _winMusicPlaying=true;
            }
        }
        _helpText.text = "";
        if(!_isDead)
        {
            _squidColliderTenticlesUp.enabled=false;
            _squidColliderTenticlesDown.enabled=false;
            transform.Rotate(0,0,Time.deltaTime*75*-1,Space.Self);
            Vector3 currentScale = transform.localScale;

            if(transform.position.y>0)transform.position += new Vector3(0,Time.deltaTime*-5f);
            if(transform.position.y<0)transform.position += new Vector3(0,Time.deltaTime*5f);
            if(transform.position.x>10)transform.position += new Vector3(Time.deltaTime*-5f,0);
            if(transform.position.x<10)transform.position += new Vector3(Time.deltaTime*5f,0);

            Debug.Log(Time.deltaTime);

            if(transform.localScale.y>1f)transform.localScale = new Vector3(currentScale.x*(1-Time.deltaTime),currentScale.y*(1-Time.deltaTime));
            else 
            {
                _squidAnimator.SetBool("IsDead",true);
                _isDead=true;
            }
        }
        else
        {
            _squidColliderTenticlesUp.enabled=true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() == null)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
