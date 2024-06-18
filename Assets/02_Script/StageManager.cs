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

    public static float[] inkLimits = { 12.5f, 7.5f, 6f, 10f, 12.5f, 10f, 10f, 10f, 10f };
    public float[] maxInk = new float[inkLimits.Length];

    public int[] starCount = new int[10];

    public bool[] stagePlayed = new bool[10];

    private int currentLevel = 0;
    public int bestLevel = 1;

    public bool isStageClicked = false;

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
        for (int i = 0; i < stagePlayed.Length - 1; i++)
        {
            stagePlayed[i] = false;
            starCount[i] = 0;
        }
        Debug.Log("Start");
    }

    private void Update()
    {
        if (bestLevel < currentLevel)
            bestLevel = currentLevel;

        if (GameObject.Find(bestLevel.ToString()))
        {
            Button button = GameObject.Find(bestLevel.ToString()).GetComponent<Button>();
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
}
