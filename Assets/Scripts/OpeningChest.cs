using TMPro;
using UnityEngine;
using System.Collections;

public class OpeningChest : MonoBehaviour
{
    public Transform lid; 
    public float openAngle = 90f;
    public float speed = 2f;
    private bool isOpen = false;
    public GameObject Player;
    bool playerInRange = false;
    public GameObject InteractText;
    public GameObject InteractImage;
    public CoinCounter coinCounter;
    public float fireRate;
    public float fireballSpeed;
    public float firballDamage;
    public Fireballs fireballs;
    public GameObject ChestInteractFirerateText;
    public GameObject ChestInteractFireballSpeedText;

    void Update()
    {
        //If the Player has less then 10 coins make the chest popup text red else make it yellow
        OpenChest();
        if (coinCounter.counter < 10)
        {
            InteractText.GetComponent<TextMeshProUGUI>().faceColor = new Color32(250, 50, 20, 255);
        }
        else
        {
            InteractText.GetComponent<TextMeshProUGUI>().faceColor = new Color32(255, 255, 0, 255);
        }
    }

    //If the player is close enough to the chest display the open chest popup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            InteractText.SetActive(true);
            InteractImage.SetActive(true);
        }
    }

    //if the player is far away from the chest remove the open chest popup
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            InteractText.SetActive(false);
            InteractImage.SetActive(false);
        }
    }


    void OpenChest()
    {
        /*If the player presses E, is in range of the chest and has 10 or more coins generate a random 
        number either 0 or 1 call the upgradeStats function, decrease the players coins by 10
        update the coinText in the top right of the players screen and destroy the chest game object*/
        if (Input.GetKeyDown(KeyCode.E) && playerInRange == true && coinCounter.counter >= 10)
        {
            int value = Random.Range(0, 2);
            upgradeStats(value);
            isOpen = !isOpen;
            coinCounter.counter -= 10;
            coinCounter.CoinText.GetComponent<TextMeshProUGUI>().text = "Coin: " + coinCounter.counter;
            Destroy(gameObject, 1f);
        }

        //If the chest is open up the lid of the chest
        Quaternion targetRotation = isOpen ? Quaternion.Euler(-openAngle, 0, 0) : Quaternion.identity;
        lid.localRotation = Quaternion.Lerp(lid.localRotation, targetRotation, Time.deltaTime * speed);
        

    }

    /*If the random value is 0 increase the fire rate by 0.1 seconds
     * else increase the movement speed of the fireball by 10
       and display the updated stats text for 3 seconds*/
    void upgradeStats(int value)
    {
        if (value == 0)
        {
            fireballs.upgradeStats(fireRate -= 0.1f, value);
            ChestInteractFirerateText.SetActive(true);
            Invoke("RemoveTextAfterDelay", 3f);

        }
        else if(value == 1)
        {
            fireballs.upgradeStats(fireballSpeed += 10f, value);
            ChestInteractFireballSpeedText.SetActive(true);
            Invoke("RemoveTextAfterDelay", 3f);
        }
    }

    //Remove the upgraded stat texts
    void RemoveTextAfterDelay()
    {
        ChestInteractFireballSpeedText.SetActive(false);
        ChestInteractFireballSpeedText.SetActive(false);
    }

}