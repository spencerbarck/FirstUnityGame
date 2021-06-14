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
    public float getSpeed()
    {
        return _speed;
    }
    void Awake()
    {
        _input = new Playerinput();
        _input.Squid.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
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
            Vector2 characterScale = transform.localScale * 2;
            transform.localScale = characterScale;
            SoundManagerScript.PlaySound("PufferfishPickup");
            transform.eulerAngles = new Vector3(0,0,0);
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
        else if(collision.collider.GetComponent<ReefWeed>() != null)
        {
            Vector3 hit = collision.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);

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
        else
        {
            SoundManagerScript.PlaySound("Death");
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SeaWeed>() != null)_leftWeeds=false;
        if(collision.collider.GetComponent<ReefWeed>() != null)_leftWeeds=false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SeaWeed>() != null)_leftWeeds = true;
        if(collision.collider.GetComponent<ReefWeed>() != null)_leftWeeds=true;
    }

    private void Update()
    {
        if(_leftWeeds)
        {
            _inTheWeeds=false;
            _leftWeeds=false;
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
