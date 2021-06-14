using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PearlPickup : MonoBehaviour
{
    public Text _helpText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<SquidPlayer>() != null)
        {

            foreach (BoarderObject b in Object.FindObjectsOfType<BoarderObject>()) 
            {
                b.DestroyBoarder();
            }
            _helpText.text = "";
                
            Destroy(gameObject);
        }
    }
}
