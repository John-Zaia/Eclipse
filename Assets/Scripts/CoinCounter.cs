using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter;
    public GameObject CoinText;
    public AudioSource CoinAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*If the player collides with a GameObject tagged "Coin"
          play the coin audio, add 1 to the counter, update
          the coin graphic on the UI and destroy the coin*/
        if(other.CompareTag("Coin"))
        {
            CoinAudio.Play();
            counter++;
            CoinText.GetComponent<TextMeshProUGUI>().text = "Coin: " + counter;
            Destroy(other.gameObject);
        }
    }
}   
    