using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform target;
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn an enemy every 1 second
        InvokeRepeating(nameof(SpawnEnemy), 0, 1f);
    }

    //Set a random spawn position within 13 units in x and z direction of the player
    void Update()
    {
        spawnPos = new Vector3(Random.Range(target.position.x - 13, target.position.x + 13),
            target.position.y,
            Random.Range(target.position.z - 13, target.position.z + 13));
    }
    // Update is called once per frame
    //Instantiate and enemy with a random spawn position
    void SpawnEnemy()
    {
        Instantiate(Enemy, spawnPos, Quaternion.identity);
    }
}
