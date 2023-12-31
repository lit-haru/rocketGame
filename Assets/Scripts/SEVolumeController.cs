using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//効果音の音量を制御するスクリプト
public class SEVolumeController : MonoBehaviour
{
    public Slider SESlider;

    void Start()
    {
        SESlider.value = PlayerPrefs.GetFloat("SEVolume",0.5f);
    }

    public void SoundSliderOnValueChange(float SEnewSliderValue)
    {
        PlayerPrefs.SetFloat("SEVolume", SEnewSliderValue);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat("SEVolume",0.5f);
    }
}
