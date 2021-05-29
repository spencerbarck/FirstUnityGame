using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    
    private Vector3 _initialPosition;
    private bool _birdLaunched;
    private bool _birdOutOfHand;
    private float _timeSitting;
    private float _timeAttack;
    private bool _attacking;
    [SerializeField] private float _launchPower;
    private bool _enlarged;
    private bool _reduced;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _initialPosition = transform.position;
        _launchPower = 125;
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            _rb.velocity = new Vector2(birdVelocity.x,10.0f);

            _rb.angularVelocity = 0.0f;
            transform.eulerAngles = new Vector3(0,0,0);

            SoundManagerScript.PlaySound("jump");
        }

        if (Input.GetKeyDown(KeyCode.D)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            _rb.velocity = new Vector2(10.0f,birdVelocity.y);

            Vector2 characterScale = transform.localScale;
            if(characterScale.x<0.0f)characterScale.x = characterScale.x*-1;
            transform.localScale = characterScale;
            SoundManagerScript.PlaySound("SideFly");
        }

        if (Input.GetKeyDown(KeyCode.A)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            _rb.velocity = new Vector2(-20.0f,birdVelocity.y);

            Vector2 characterScale = transform.localScale;
            if(characterScale.x>0.0f)characterScale.x = characterScale.x*-1;
            transform.localScale = characterScale;
            SoundManagerScript.PlaySound("SideFly");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            Vector2 beforeBlink = transform.position;
            if(birdVelocity.x>0.0f) transform.position = new Vector2(beforeBlink.x+6, beforeBlink.y);
            else transform.position = new Vector2(beforeBlink.x-6, beforeBlink.y);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)&&_birdLaunched)
        {
            Vector2 characterScale = transform.localScale;
            characterScale.x = characterScale.x*30;
            transform.localScale = characterScale;
            _attacking = true;
            SoundManagerScript.PlaySound("Expand");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            _rb.velocity = new Vector2(-50.0f,-50.0f);

            Vector2 characterScale = transform.localScale;
            if(characterScale.x>0.0f)characterScale.x = characterScale.x*-1;
            transform.localScale = characterScale;
            SoundManagerScript.PlaySound("DiagonalAttack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            _rb.velocity = new Vector2(0f,-100.0f);
            SoundManagerScript.PlaySound("GroundAttack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)&&_birdLaunched)
        {
            Vector2 characterScale = transform.localScale;

            Vector2 birdVelocity = _rb.velocity;
            if(characterScale.x>0.0f)_rb.velocity = new Vector2(50.0f,0.0f);
            if(characterScale.x<0.0f)_rb.velocity = new Vector2(-50.0f,0.0f);
            
            SoundManagerScript.PlaySound("SideFly");
        }

        if (Input.GetKeyDown(KeyCode.W)&&_birdLaunched)
        {
            if(!_enlarged){
                Vector2 characterScale = transform.localScale * 5;
                transform.localScale = characterScale;
                SoundManagerScript.PlaySound("Enlarge");
                if(_reduced){
                    _reduced=false;
                }else{
                    _enlarged=true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S)&&_birdLaunched)
        {
            if(!_reduced){
                Vector2 characterScale = transform.localScale / 5;
                transform.localScale = characterScale;
                SoundManagerScript.PlaySound("Reduce");
                if(_enlarged){
                    _enlarged=false;
                }else{
                    _reduced=true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E)&&_birdLaunched)
        {
            _rb.angularVelocity = 0.0f;
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if (Input.GetKeyDown(KeyCode.R)&&_birdLaunched)
        {
            if(_rb.angularVelocity == 0.0f)  _rb.angularVelocity = 1f;
            _rb.angularVelocity = _rb.angularVelocity*1.25f;
        }

        if (Input.GetKeyDown(KeyCode.Q)&&_birdLaunched)
        {
            Vector2 birdVelocity = _rb.velocity;
            _rb.velocity = new Vector2(birdVelocity.x/2,birdVelocity.y);
        }

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdLaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5)
        {
            _timeSitting += Time.deltaTime;
        }

        if (_attacking)
        {
            _timeAttack += Time.deltaTime;
        }

        if(_timeAttack>1)
        {
            Vector2 characterScale = transform.localScale;
            characterScale.x = characterScale.x/30;
            transform.localScale = characterScale;
            _attacking=false;
            _timeAttack=0;
            SoundManagerScript.PlaySound("Expand");
        }
        

        if (transform.position.y > _initialPosition.y+10||
            transform.position.y < _initialPosition.y-10||
            transform.position.x > _initialPosition.x+10||
            transform.position.x < _initialPosition.x-10)
        {
            _birdOutOfHand = true;
        }

        if (_birdOutOfHand && !_birdLaunched)
        {
            //string currentSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(currentSceneName);
        }
        if (_timeSitting > 1.5||
            transform.position.y > 100||
            transform.position.y < -100||
            transform.position.x > 200||
            transform.position.x < -100)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            SoundManagerScript.PlaySound("OutOfBounds");
        }
    }
    private void OnMouseDown()
    {
        GetComponent<LineRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().color = RandColorHelper();
        SoundManagerScript.PlaySound("PullBack");
    }

    private void OnMouseUp()
    {
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPostion = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPostion * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdLaunched = true;
        SoundManagerScript.PlaySound("Slingshot");
    }

    private void OnMouseDrag()
    {
        if(!_birdOutOfHand)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3 (newPosition.x,newPosition.y);
        }
    }

    private Color32 RandColorHelper()
    {
        System.Random r = new System.Random();
        byte red = System.Convert.ToByte(r.Next(256));
        byte green = System.Convert.ToByte(r.Next(256));
        byte blue = System.Convert.ToByte(r.Next(256));
        
        return new Color32( red, green, blue, 255 );
    }
}
