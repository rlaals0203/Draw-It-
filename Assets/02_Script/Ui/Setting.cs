using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Setting : MonoBehaviour
{
    static public bool isSettingOpen = false;
    private bool isCoolTime = false;

    [SerializeField] private GameObject settingUI;
    [SerializeField] private RawImage background;
    [SerializeField] private Button muteBGM;
    [SerializeField] TMP_Text muteBGMText;

    private void Awake()
    {
        muteBGM = GetComponent<Button>();
    }

    private void Start()
    {
        Player.Instance.isReset = false;
        isSettingOpen = false;
    }

    public void OnSettingOpen()
    {
        if (!isSettingOpen && !isCoolTime)
        {
            isCoolTime = true;
            isSettingOpen = true;
            settingUI.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutQuart);
            background.gameObject.SetActive(true);
            background.DOFade(0.9f, 0.5f);
            StartCoroutine(WaitTweening(0.5f, 0f));
        }
        else if(isSettingOpen && !isCoolTime)
        {
            isCoolTime = true;
            StartCoroutine(WaitTweening(0f, 1f));
            isSettingOpen = false;
            settingUI.transform.DOLocalMoveY(-1000, 0.5f).SetEase(Ease.OutQuart);
            background.DOFade(0f, 0.5f);
        }
    }

    public void OnExitButton()
    {
        Time.timeScale = 1;
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

    IEnumerator WaitTweening(float time, float timeScale)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = timeScale;
        isCoolTime = false;
    }
}
