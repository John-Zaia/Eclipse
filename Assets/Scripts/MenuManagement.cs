using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    // Start is called before the first frame update
    //Load level one if the Start button is hit
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    //Exit the app if the Quit button is hit
    public void Quit()
    {
        Application.Quit();
    }

    //Play a clicking noise everytime a button is clicked
    public void OnButtonClick()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
