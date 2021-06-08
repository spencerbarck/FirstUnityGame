using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfishEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() != null)
        {
            Destroy(gameObject);
        }
    }
}
