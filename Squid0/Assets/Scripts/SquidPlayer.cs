using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SquidPlayer : MonoBehaviour
{
    //CuddleFish Collide?
    private Playerinput _input;
    private Vector2 _moveAxis;
    [SerializeField]private float _speed = 2;
    private bool _inTheWeeds;
    private bool _leftWeeds;
    [SerializeField]
    private float _weedSlowFactor = 4;
    private Rigidbody2D rb;
    public bool _isLarge;
    public int _sizeFactor=1;
    private float _shrinkDeathTimer;
    [SerializeField]
    private bool _insideBoss;
    private LevelControlScript _levelControl;
    public Animator _squidAnimator;
    public PolygonCollider2D _squidCollider;
    public PolygonCollider2D _squidColliderLarge;
    public float getSpeed()
    {
        return _speed;
    }
    void Awake()
    {
        _input = new Playerinput();
        _input.Squid.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());

        _levelControl=FindObjectOfType<LevelControlScript>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _squidColliderLarge.enabled=false;
        _input.Squid.Fire.Enable();
        _input.Squid.Fire.performed += HandleFire;

        _input.Squid.Movement.Enable();
    }

    public void HaltSquidForWin()
    {
        _input.Squid.Movement.Disable();
        _moveAxis.x = 0f;
        _moveAxis.y = 0f;
        transform.eulerAngles = new Vector3(0,0,0);
    }

    private void HandleFire(InputAction.CallbackContext context)
    {
    }
    
    private void Move(Vector2 direction)
    {
        _moveAxis = direction;

        Vector2 characterScale = transform.localScale;
        if(direction.x>0)
        {
            if(characterScale.x<0.0f)characterScale.x = characterScale.x*-1;
        }
        if(direction.x<0)
        {
            if(characterScale.x>0.0f)characterScale.x = characterScale.x*-1;
        }
        transform.localScale = characterScale;
    }

    private void OnDisable()
    {
        _input.Squid.Fire.Disable();
        _input.Squid.Fire.performed -= HandleFire;

        _input.Squid.Movement.Disable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<StarfishEnemy>() != null)
        {
            if(collision.collider.GetComponent<StarfishLargeEnemy>() != null)
            {
                _speed+=4;
            }else _speed+=2;
            SoundManagerScript.PlaySound("StarfishPickup");
            transform.eulerAngles = new Vector3(0,0,0);
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if(collision.collider.GetComponent<JumboShrimpEnemy>() != null)
        {
            Enlarge();
            SoundManagerScript.PlaySound("ShrimpPickup");
        }
        else if(collision.collider.GetComponent<Teleboarder>() != null)
        {
            Vector2 velocity = rb.velocity;
            Teleboarder tB = collision.collider.GetComponent<Teleboarder>();
            if(tB.transform.position.y>2)
            {
                transform.position += new Vector3(0,-24f);
                rb.velocity = new Vector2(0,velocity.y);
            } 
            if(tB.transform.position.y<-2)
            {
                transform.position += new Vector3(0,24f);
                rb.velocity = new Vector2(0,velocity.y);
            }
            if(tB.transform.position.x<-20) 
            {
                transform.position += new Vector3(44f,0);
                rb.velocity = new Vector2(velocity.x,0);
            }
            if(tB.transform.position.x>20)
            {
                transform.position += new Vector3(-44f,0);
                rb.velocity = new Vector2(velocity.x,0);
            }
        }
        else if(collision.collider.GetComponent<PufferFishEnemy>() != null)
        {
            _speed = _speed / 2;
            SoundManagerScript.PlaySound("PufferfishPickup");
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(collision.collider.GetComponent<SeaWeed>() != null)
        {
            _inTheWeeds=true;
        }
        else if(collision.collider.GetComponent<PearlPickup>() != null)
        {
            _levelControl.SpawnShrimp();
            SoundManagerScript.PlaySound("PearlPickup");
        }
        else if(collision.collider.GetComponent<ReefWeed>() != null)
        {
            Vector3 hit = collision.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);

            if(collision.collider.GetComponent<ReefWeed>()._weedLeft)
            {
                if(Mathf.Approximately(angle, 90)){
                    Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y >= 0)
                    {
                        SoundManagerScript.PlaySound("Death");
                        Destroy(gameObject);
                    }
                }
                _inTheWeeds=true;
            }
            else
            {
                if(Mathf.Approximately(angle, 90)){
                    Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y < 0)
                    {
                        SoundManagerScript.PlaySound("Death");
                        Destroy(gameObject);
                    }
                }
                _inTheWeeds=true;
            }
        }
        else if(collision.collider.GetComponent<PorcupinePufferEnemy>() != null)
        {
            PorcupinePufferEnemy ppe = collision.collider.GetComponent<PorcupinePufferEnemy>();
            if(ppe.GetIsSpiked())
            {
                SoundManagerScript.PlaySound("Death");
                Destroy(gameObject);
            }
            else
            {
                _speed = _speed / 2;
                SoundManagerScript.PlaySound("PufferfishPickup");
                transform.eulerAngles = new Vector3(0,0,0);
            }
        }
        else if(collision.collider.GetComponent<GiantSquidBoss>() != null)
        {

            if(collision.collider.GetComponent<GiantSquidBoss>()._isDead)
            {
                SoundManagerScript.PlaySound("Giant Squid Eat");
                Destroy(collision.collider.GetComponent<GiantSquidBoss>().gameObject);
            }
            else
            {
                if(!_insideBoss)
                {
                    if(_isLarge)
                    {
                        SoundManagerScript.PlaySound("Giant Squid Hurt");
                        collision.collider.GetComponent<GiantSquidBoss>().ReduceHealth();
                        _insideBoss = true;
                        Shrink();

                    }
                    else
                    {
                        Debug.Log("Before Hit:"+_sizeFactor);
                        SoundManagerScript.PlaySound("Death");
                        Destroy(gameObject);
                    }
                }
            }
            
        }
        else if(((collision.collider.GetComponent<LobsterEnemy>() != null)||
            (collision.collider.GetComponent<CrabEnemy>() != null))&&_isLarge)
        {
            Shrink();
            Destroy(collision.collider.gameObject);
        }
        else if((collision.collider.GetComponent<TunaObject>() != null)&&_sizeFactor>2)
        {
            Shrink();
            Destroy(collision.collider.gameObject);
        }
        else if((collision.collider.GetComponent<TurtleObject>() != null)&&_sizeFactor>3)
        {
            Shrink();
            Destroy(collision.collider.gameObject);
        }
        else
        {
            _isLarge=false;
            _insideBoss=false;
            SoundManagerScript.PlaySound("Death");
            Destroy(gameObject);
        }
    }

    private void Shrink()
    {
        _levelControl.SpawnShrimp();
        Vector2 characterScale = transform.localScale / 2;
        _sizeFactor--;
        if(_sizeFactor==1)
        {
            _squidColliderLarge.enabled=false;
            _squidCollider.enabled=true;
            _squidAnimator.SetBool("IsLarge",false);
            _isLarge=false;
        }
        else
        {
            transform.localScale = characterScale;
        }
        SoundManagerScript.PlaySound("Shrink");
    }

    private void Enlarge()
    {
        Vector2 characterScale = transform.localScale * 2;
        if(_isLarge)transform.localScale = characterScale;
        transform.eulerAngles = new Vector3(0,0,0);
        _squidColliderLarge.enabled=true;
        _squidCollider.enabled=false;
        _squidAnimator.SetBool("IsLarge",true);
        _isLarge=true;
        _sizeFactor++;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SeaWeed>() != null)_leftWeeds=false;
        if(collision.collider.GetComponent<ReefWeed>() != null)_leftWeeds=false;
        //if(collision.collider.GetComponent<GiantSquidBoss>() != null)_insideBoss=true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SeaWeed>() != null)_leftWeeds=true;
        if(collision.collider.GetComponent<ReefWeed>() != null)_leftWeeds=true;
    }

    private void Update()
    {
        if(_leftWeeds)
        {
            _inTheWeeds=false;
            _leftWeeds=false;
        }

        if(_insideBoss)
        {
            _shrinkDeathTimer+=Time.deltaTime;
            if(_shrinkDeathTimer>0.5)
            {
                _insideBoss=false;
                _shrinkDeathTimer=0;
            }
        }

        if(_inTheWeeds){
            float weedSpeed = _speed/_weedSlowFactor;
            transform.position += new Vector3(_moveAxis.x * Time.deltaTime * weedSpeed,_moveAxis.y * Time.deltaTime * weedSpeed);
        }
        else
        {
            transform.position += new Vector3(_moveAxis.x * Time.deltaTime * _speed,_moveAxis.y * Time.deltaTime * _speed);
        }
    }
}
