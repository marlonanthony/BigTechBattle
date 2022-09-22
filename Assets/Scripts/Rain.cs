using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";
    private const string ENEMY_TAG = "Enemy";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(other.gameObject);
        }
    }
}
