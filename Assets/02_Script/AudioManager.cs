using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


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
    public Event ToggleBGM;

    public static AudioManager Instance = null;

    [SerializeField] private Slider sliderSFX;

    [SerializeField] private AudioClip[] soundList;

    [SerializeField] private AudioSource bgm;

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.soundList[(int)sound], volume);
    }
}
