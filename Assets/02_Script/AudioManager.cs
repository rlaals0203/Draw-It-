using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SoundType
{
    CLICK,
    COMPLETE,
    JUMP,
    PURCHASE,
    PURCHASE_FAIL,
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    private static float _volume;

    [SerializeField] private Slider sliderSFX;

    [SerializeField] private AudioClip[] soundList;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound)
    {
        Instance.audioSource.PlayOneShot(Instance.soundList[(int)sound], _volume);
    }

    public void VolumeSetting(float value)
    {
        _volume = value;
    }
}
