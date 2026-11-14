using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public static Volume Instance;

    public AudioMixer masterMixer;

    private const string MixerParamName = "Volume";

    private float currentVolume = 1f;

    void Awake()
    {
        //Make sure there is only one audio mixer and don't destroy it when loading different scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
            return;
        }
    }

    //convert the volume to decibel values and set the decible value to the audio mixer
    public void SetVolume(float sliderValue)
    {
        currentVolume = sliderValue;
        float volumeInDecibels = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
        masterMixer.SetFloat(MixerParamName, volumeInDecibels);
    }
}