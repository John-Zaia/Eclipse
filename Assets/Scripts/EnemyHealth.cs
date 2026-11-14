using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float fireballDamage = 50;
    public GameObject Coin;
    Vector3 EnemyDeathPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the Enemy is hit with a fireball deal 50 damage
        if (collision.gameObject.CompareTag("Fireball"))
        {
            health = health - fireballDamage;
        }

        /*If the enemies health is equal to 0 get the location of the enemies death,
          destroy the enemy GameObject and Instantiate a coin at the location
          of the death*/
        if (health == 0) 
        { 
            EnemyDeathPosition = gameObject.transform.position + new Vector3 (0, 1, 0);
            Destroy(gameObject);
            Instantiate(Coin, EnemyDeathPosition, Quaternion.identity); 
        }
           
    }
}
