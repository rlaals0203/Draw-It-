using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.soundList[(int)sound], volume);
    }
}
