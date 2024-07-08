using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    public GameObject[] maps;
    public GameObject currentMap;

    [SerializeField] private float[] inkLimits;
    public float[] maxInk = new float[10];

    public int[] starCount = new int[10];

    public bool[] stagePlayed = new bool[10];
    public bool[] stageComplete = new bool[10];

    public int currentLevel = 0;
    public int bestLevel = 1;

    public bool isStageClicked = false;
    public bool isAntiDraw = false;

    public string currentSkin;

    private void Awake()
    {
        bestLevel = PlayerPrefs.GetInt("BestLevel");

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
        for (int i = 0; i < stagePlayed.Length - 1; i++)
        {
            stagePlayed[i] = false;
            stageComplete[i] = false;
            starCount[i] = 0;
        }
    }

    private void Update()
    {
        currentSkin = Shop.skinName;

        if (bestLevel < currentLevel)
        {
            bestLevel++;
            PlayerPrefs.SetInt("BestLevel", bestLevel);
        }
    }

    private void GenerateMap()
    {
        if (SceneManager.GetActiveScene().name != "Level")
            SceneManager.LoadScene("Level");

        currentMap = Instantiate(currentMap, new Vector3(0, 0, 0), Quaternion.identity);

        DontDestroyOnLoad(currentMap);
    }

    public void OnStageClick()
    {
        currentLevel = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        currentMap = maps[currentLevel - 1];

        if (!stagePlayed[currentLevel - 1])
        {
            stagePlayed[currentLevel - 1] = true;
        }

        GenerateMap();
    }

    public float GetInkLimit()
    {
        return inkLimits[currentLevel - 1];
    }

    public void SetMaxInk()
    {
        if (maxInk[currentLevel - 1] < Player.Instance.inkLeft)
        {
            maxInk[currentLevel - 1] = Player.Instance.inkLeft;
        }
    }

    public void NextStage()
    {
        currentLevel++;
        Destroy(currentMap);
        currentMap = maps[currentLevel - 1];
        GenerateMap();
    }

    public int FirstPlayed()
    {
        return currentLevel;
    }

    public void SetStageButton()
    {
        bestLevel = PlayerPrefs.GetInt("BestLevel");

        for (int i = 0; i < bestLevel; i++)
        {
            Button button = GameObject.Find((i + 1).ToString()).GetComponent<Button>();
            button.interactable = true;
        }
    }
}
