using Ilumisoft.HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireball : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //if a fireball collides with an enemy destroy the fireball
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
