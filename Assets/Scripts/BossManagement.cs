using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class BossManagement : MonoBehaviour
{
    NavMeshAgent Nav;
    public Transform target;
    public Animator anim;

    public float damage = 10f;
    public float attackInterval = 1f;
    bool inRange = false;
    float nextAttackTime = 0f;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        /*initalizing the boss' navigation mesh and 
          animations setting the target to the player
          and getting the players health*/
        Nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        playerHealth = target.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Nav.SetDestination(target.position);

        /*If player is in Range of the boss and 
          if its been longer then one second since
          the last attack the enemy deals damage
          to the player and starts timing the next
          attack*/
        if (inRange && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

    }

    void SpawnEnemy()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /*If Player is colliding with the boss
          Attack every one second*/
        if (other.CompareTag("Player"))
        {
            nextAttackTime = Time.time + attackInterval;
            anim.SetBool("InRange", true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*If player isn't colliding with 
          the boss the enemy stops attacking*/
        if (other.CompareTag("Player"))
        {
            anim.SetBool("InRange", false);
            inRange = false;
        }
    }

}
