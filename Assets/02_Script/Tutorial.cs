using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private int stageNum;
    private int prevStage;

    private GameObject tutorial;
    [SerializeField] private GameObject skipButton;

    private GameObject tutorialParent;

    private int stageNumber
    {
        get => StageManager.Instance.FirstPlayed();

        set
        {
            stageNum = value;
        }
    }

    private void Update()
    {
        if (!StageManager.Instance.stagePlayed[stageNumber] && GameObject.Find("Canvas"))
        {
            GenerateTutorial();
        }
    }

    private void GenerateTutorial()
    {
        FindObject();

        if (skipButton != null)
            skipButton.SetActive(true);

        if (skipButton == null)
        {
            GenerateTutorial();
            return;
            print("aaa");
        }

        StageManager.Instance.stagePlayed[stageNumber] = true;
        tutorial = tutorialParent.transform.Find($"Tutorial{stageNumber}").gameObject;

        if (tutorial != null)
            tutorial.SetActive(true);
    }

    public void TutorialClicked()
    {
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

    private void FindObject()
    {
        tutorialParent = GameObject.Find("Tutorial");
        //skipButton = GameObject.Find("SkipButton");
    }
}
