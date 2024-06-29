using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    static public bool isSettingOpen = false;

    [SerializeField] private GameObject settingUI;
    [SerializeField] private Button muteBGM;
    [SerializeField] TMP_Text muteBGMText;

    private void Awake()
    {
        muteBGM = GetComponent<Button>();
    }

    private void Start()
    {
        Player.Instance.isReset = false;
        settingUI.SetActive(false);
        isSettingOpen = false;
    }

    public void OnSettingOpen()
    {
        isSettingOpen = !isSettingOpen;
        settingUI.SetActive(isSettingOpen);
    }

    public void OnExitButton()
    {
        Destroy(StageManager.Instance.currentMap);
        SceneManager.LoadScene("Menu");
    }

    public void OnMuteBGM()
    {
        StatManager.Instance.isMutedBGM = !StatManager.Instance.isMutedBGM;

        if (StatManager.Instance.isMutedBGM)
        {
            muteBGMText.text = "²ô±â";
        }
        else
        {
            muteBGMText.text = "ÄÑ±â";
        }
    }
}
