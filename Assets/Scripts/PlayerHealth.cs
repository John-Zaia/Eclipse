using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI HealthField;
    public Image RedBar;
    public Image GreenBar;
    public float health = 100f;
    public GameObject FireballAudio;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        //Decrease health by the amount of damage taken and decrease the value of the health bar
        health -= damage;
        GreenBar.fillAmount = health / 100f;

        /*If the players health is 0 Destroy the player, fireball audio, 
          unlock the cursor, make the cursor video, and display the 
          you died screen*/
        if(health <= 0)
        {
            Destroy(gameObject);
            Destroy(FireballAudio);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }
}
