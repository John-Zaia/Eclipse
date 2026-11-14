using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float health = 1000;
    public float fireballDamage = 50;
    GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If boss is hit with fireball reduce his health
        if (collision.gameObject.CompareTag("Fireball"))
        {
            health = health - fireballDamage;
        }

        /*If boss health is equal to 0 destroy the boss and Player
          unlock and make the cursor visible and switch to the
          You Win Screen*/
        if (health == 0)
        {
            Destroy(gameObject);
            Destroy(Player);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(4);
        }

    }
}
