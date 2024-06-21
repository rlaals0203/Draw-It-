using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StageClickEvent : MonoBehaviour
{
    private Button stageButton;

    void Start()
    {
        stageButton = GetComponent<Button>();
        stageButton.onClick.AddListener(() => StageManager.Instance.OnStageClick());
    }
}
