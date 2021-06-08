using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SquidPlayer : MonoBehaviour
{
    private Playerinput _input;
    private Vector2 _moveAxis;
    [SerializeField]private float _speed = 2;
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
        }
        else if(collision.collider.GetComponent<PufferFishEnemy>() != null)
        {
            _speed = _speed / 2;
            SoundManagerScript.PlaySound("PufferfishPickup");
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            SoundManagerScript.PlaySound("Death");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position += new Vector3(_moveAxis.x * Time.deltaTime * _speed,_moveAxis.y * Time.deltaTime * _speed);
    }
}
