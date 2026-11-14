using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeath : MonoBehaviour
{
    public GameObject FireballAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if players y position is less than 50
         destroy the player GameObject, destroy
         the FireballAudio Gameobject, unlock
         the cursor and load the death screen*/
        if(gameObject.transform.position.y <= -50f)
        {
            Destroy(gameObject);
            Destroy(FireballAudio);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }
}
