using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] sfxClips;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(musicClips, x => x.name == name);

        if (s == null)
        {
            Debug.Log("음악을 찾을수 없습니다");
        }
        else
        {

        }
    }
}
