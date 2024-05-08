using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    public GameObject[] maps;
    private GameObject currentMap;
    private GameObject prevMap;

    public static float[] inkLimits = { 10, 7.5f, 5f, 12.5f, 10 };
    public float[] leastInk = new float[inkLimits.Length];

    private int currentLevel = 0;

    public bool isStageClicked = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (isStageClicked)
        {
            isStageClicked = false;
            SceneManager.LoadSceneAsync("Level");

            currentMap = Instantiate(currentMap, new Vector3(0, 0, 0), Quaternion.identity);
            DontDestroyOnLoad(currentMap);
        }

        if (currentMap == null)
        {
            currentMap = Instantiate(currentMap, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void OnStageClick()
    {
        currentLevel = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        currentMap = maps[currentLevel - 1];
        isStageClicked = true;
    }

    public float GetInkLimit()
    {
        return inkLimits[currentLevel - 1];
    }

    public void SetLeastInk()
    {
        if (inkLimits[currentLevel - 1] < Player.Instance.inkLeft)
        {
            inkLimits[currentLevel - 1] = Player.Instance.inkLeft;
        }
    }

    public void NextStage()
    {
        currentLevel++;
        Destroy(currentMap);
        currentMap = maps[currentLevel - 1];
        isStageClicked = true;
    }
}
