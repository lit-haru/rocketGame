using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//BGMの音量を制御するスクリプト
public class BGMPlayController : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider slider;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.volume = PlayerPrefs.GetFloat("BGMVolume");
        slider.value = PlayerPrefs.GetFloat("BGMVolume");
    }

    public void SoundSliderOnValueChange(float BGMnewSliderValue)
    {
        audioSource.volume = BGMnewSliderValue;

        PlayerPrefs.SetFloat("BGMVolume", BGMnewSliderValue);
        PlayerPrefs.Save();
    }
}
