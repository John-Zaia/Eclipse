using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManagement : MonoBehaviour
{
    public GameObject InteractText;
    public GameObject InteractImage;
    public GameObject Player;
    public GameObject FireballAudio;
    bool inRange;
    public BossHealth bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If in range of the portal and pressing E teleport player to the boss level
        if(inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            SpawnPlayerAtBoss();
        }
    }

    //if the player is close enough to the portal bring up the take portal popup
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InteractText.SetActive(true);
            InteractImage.SetActive(true);
            inRange = true;
        }
    }

    //if the player is out of the portals range remove the popup
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InteractText.SetActive(false);
            InteractImage.SetActive(false);
            inRange = false;
        }
    }

    //instantiate a copy of the player at the final boss level and don't destroy the player object or the fireball audio
    private void SpawnPlayerAtBoss()
    {
        GameObject player = Instantiate(Player);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(FireballAudio);
        SceneManager.LoadScene(3);

    }
}

