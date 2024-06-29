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

    private void Update()
    {
        if (!StageManager.Instance.stagePlayed[StageManager.Instance.currentLevel - 1] && GameObject.Find("Canvas"))
        {
            GenerateTutorial();
        }
    }

    private void Start()
    {
        FindObject();
    }

    private void GenerateTutorial()
    {
        StageManager.Instance.stagePlayed[StageManager.Instance.currentLevel - 1] = true;
        tutorial = tutorialParent.transform.Find($"Tutorial{StageManager.Instance.currentLevel}").gameObject;

        if (skipButton == null)
        {
            GenerateTutorial();
            return;
        }

        if (tutorial != null)
            tutorial.SetActive(true);
        else
            return;

        if (skipButton != null)
            skipButton.SetActive(true);
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
    }
}
