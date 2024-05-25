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

        Instance = this;

        star = PlayerPrefs.GetInt("Star");
}

    public void GetStar(int value)
    {
        star += value;
        PlayerPrefs.SetInt("Star", star);
    }
}
