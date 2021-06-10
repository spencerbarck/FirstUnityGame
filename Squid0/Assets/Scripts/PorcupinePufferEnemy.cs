using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcupinePufferEnemy : MonoBehaviour
{
    public Animator _animator;
    private float _spikeTimer;
    private float _spikeSpeed = 4;
    private float _timeInSpikeMode;
    private bool _isSpiked;
    private float _speed = 90.0f;
    public bool GetIsSpiked()
    {
        return _isSpiked;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(!_isSpiked)
        {
            _spikeTimer+=Time.deltaTime;
            if(_spikeTimer>=_spikeSpeed)
            {
                _animator.SetBool("IsSpiked", true);
                _isSpiked = true;
                //_spikeTimer=0;
            }
        }else
        {
            if(_timeInSpikeMode<_spikeSpeed)
            {
                transform.Rotate(0,0,Time.deltaTime * _speed,Space.Self);
                _timeInSpikeMode+=Time.deltaTime;
            }
            else
            {
                _isSpiked = false;
                _timeInSpikeMode = 0;
                _spikeTimer = 0;
                transform.eulerAngles = new Vector3(0,0,0);
                _animator.SetBool("IsSpiked", false);
            }
        }       
    }
    
}
