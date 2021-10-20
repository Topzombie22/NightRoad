using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [Range(0, 1)]
    [Tooltip("Volume")]
    public AudioListener audioL;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("Volume", AudioListener.volume);
        slider.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioSlider()
    {
        AudioListener.volume = slider.value * 1.0f;
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }
}
