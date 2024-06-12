using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance = null;

    public int star = 0;
    public int diamond = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.parent);

        Instance = this;
        star = PlayerPrefs.GetInt("Star");

        star = 5555;
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
