using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))] 
public class AudioSliderEvent : MonoBehaviour
{
    private Slider volumeSlider;

    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.onValueChanged.AddListener((float value) => AudioManager.Instance.VolumeSetting(volumeSlider.value));
    }
}
