using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance = null;

    public int star = 0;
    public int diamond = 0;

    public bool isPlayed = false;
    public bool isMutedBGM = false;

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

        star = PlayerPrefs.GetInt("Star");
}

    public int GetStar()
    {
        return star;
    }

    public void AddStar(int value)
    {
        star += value;
        PlayerPrefs.SetInt("Star", star);
    }

    public void RemoveStar(int value)
    {
        star -= value;
        PlayerPrefs.SetInt("Star", star);
    }
}
