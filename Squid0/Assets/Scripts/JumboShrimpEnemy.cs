using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumboShrimpEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() != null)
        {
            //if(!(collision.collider.GetComponent<SquidPlayer>()._isLarge==true))
            //{
                Destroy(gameObject);
            //}
        }
    }
}
