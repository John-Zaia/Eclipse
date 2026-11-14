using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        //Load the main menu if player hits Main Menu button"
        SceneManager.LoadScene(0);
    }

    public void OnButtonClick()
    {
        //play the clicking noise when clicking on the button
        this.GetComponent<AudioSource>().Play();
    }
}
