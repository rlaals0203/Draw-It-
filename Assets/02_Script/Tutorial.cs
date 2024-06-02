using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private int stageNum;
    private int prevStage;

    private GameObject tutorial;
    private GameObject skipButton;

    private GameObject tutorialParent;

    private int stageNumber
    {
        get => StageManager.Instance.FirstPlayed();

        set
        {
            stageNum = value;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (!StageManager.Instance.stagePlayed[stageNumber])
        {
            GenerateTutorial();
        }
    }

    private void GenerateTutorial()
    {
        tutorialParent = GameObject.Find("Tutorial");
        skipButton = GameObject.Find("SkipButton");

        skipButton.SetActive(true);

        StageManager.Instance.stagePlayed[stageNumber] = true;
        tutorial = tutorialParent.transform.Find($"Tutorial{stageNumber}").gameObject;

        tutorial.SetActive(true);
    }

    public void TutorialClicked()
    {
        skipButton.SetActive(true);
        GenerateTutorial();
    }

    public void OnSkip()
    {
        DisableTutorial();
    }

    private void DisableTutorial()
    {
        tutorial.SetActive(false);
        skipButton.SetActive(false);
        Player.Instance.isStart = false;
    }
}
