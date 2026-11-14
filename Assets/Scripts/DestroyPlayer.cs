using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FireballAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the players position is less then -100 Destroy the Player and Fireball audio
        if(gameObject.transform.position.y < -100)
        {
            Destroy(gameObject);
            Destroy(FireballAudio);
        }
    }
}
