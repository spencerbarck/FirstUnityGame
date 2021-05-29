using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMonster : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlowerMonster flowerMonster = collision.collider.GetComponent<FlowerMonster>();
        if(flowerMonster != null)
        {
            return;
        }

        Bird bird = collision.collider.GetComponent<Bird>();
        if(bird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SoundManagerScript.PlaySound("EnemyDead");
            return;
        }

        if(collision.contacts[0].normal.y < 0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SoundManagerScript.PlaySound("EnemyDead");
            return;
        }
    }
}
