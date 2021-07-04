using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PearlPickup : MonoBehaviour
{
    public Text _helpText;
    bool _isPickedUp;
    bool _pearlMusicPlaying;

    float _pearlMusicTimer;
    float _pearlMusicTime = 2.5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() != null)
        {

            foreach (BoarderObject b in Object.FindObjectsOfType<BoarderObject>()) 
            {
                b.DestroyBoarder();
            }
            _helpText.text = "You Need Shrimp";
                
            GetComponent<PolygonCollider2D>().enabled=false;
            GetComponent<SpriteRenderer>().enabled=false;
            _isPickedUp=true;
        }
    }
    void Update()
    {
        
        if((!_pearlMusicPlaying)&&(_isPickedUp))
        {
            _pearlMusicTimer+=Time.deltaTime;
            if(_pearlMusicTimer<_pearlMusicTime)return;
            SoundManagerScript.PlaySound("PearlPickupMusic");
            _pearlMusicPlaying=true;
        }
    }
}
