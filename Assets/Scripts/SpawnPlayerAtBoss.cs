using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerAtBoss : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Don't destroy the player when moving to the final boss level and move him to a specific position
    private void SpawnPlayer()
    {
        GameObject player = Instantiate(Player);
        DontDestroyOnLoad(player);
        player.transform.position = new Vector3(416f, 117f, 246.8f);
    }
}
