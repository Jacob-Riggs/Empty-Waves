using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource volumeAudio;

    public void OnSliderChange()
    {
        volumeAudio.volume = volumeSlider.value;
    }
}
