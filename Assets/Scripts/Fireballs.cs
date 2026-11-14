using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public float fireRate = 1f;
    public float fireballSpeed = 20f;
    public AudioSource FireballAudio;
    public OpeningChest openingChest;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        /*If the time is greater then the fire rate shoot a fireball */
        if( timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    /*Instantiate a fireball from the players Staff, Play the fireball audio
     * and transform the fireball based on the fireballSpeed*/
    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        FireballAudio.Play();

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.velocity = firePoint.forward * fireballSpeed;
        }
    }

    //if the fireball hits an enemy destroy the fireball
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(fireballPrefab);
        }
    }

    /*If opening the chest generates a value of 0 upgrade the firerate
      else upgrade the fireball shoot speed*/
    public void upgradeStats(float stats, int value)
    {
        if (value == 0)
        {
            fireRate += stats;
        }
        else if(value == 1)
        {
            fireballSpeed += stats;
        }
    }
}
