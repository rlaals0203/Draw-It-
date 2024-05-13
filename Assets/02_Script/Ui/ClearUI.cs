using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private GameObject clearUI;
    [SerializeField] private TMP_Text inkLeftUI;

    [SerializeField] private RawImage[] star;

    WaitForSeconds starCool;

    private bool isEnable = false;
    private bool isNext = false;

    private Vector3 startPos;

    private void Awake()
    {
        starCool = new WaitForSeconds(0.6f);
    }

    private void Start()
    {
        startPos = clearUI.transform.position;
    }
    private void Update()
    {
        if (!Player.Instance.isComplete)
        {
            isEnable = false;
        }

        if (Player.Instance.isComplete && !isEnable)
        {
            isEnable = true;
            StartCoroutine(ClearUIDown());
        }

        inkLeftUI.text = $"³²Àº À×Å©·® : {Mathf.Round(Mathf.Abs(Player.Instance.inkLeft * 100)),4}%";
    }

    public void PlayAgain()
    {
        Player.Instance.isReset = true;
        StartCoroutine(ClearUIUp());
    }

    public void NextStageClick()
    {
        isNext = true;
        StartCoroutine(ClearUIUp());
    }

    private void NextStage()
    {
        isNext = false;
        StageManager.Instance.NextStage();
        Player.Instance.ResetPlayer();
    }

    IEnumerator ClearUIDown()
    {
        background.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        background.DOFade(0.8f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        clearUI.transform.DOMove(new Vector3(clearUI.transform.position.x, 550, clearUI.transform.position.z), 0.75f);

        yield return new WaitForSeconds(1f);

        StartCoroutine(StarStamp());
    }

    IEnumerator ClearUIUp()
    {
        Player.Instance.isComplete = false;

        background.DOFade(0f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        clearUI.transform.DOMove(new Vector3(startPos.x, startPos.y, startPos.z), 0.75f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(0.85f);

        background.gameObject.SetActive(false);

        if (isNext)
            NextStage();

        for(int i = 0; i < 3; i++)
        {
            SetStarDefault(i);
        }
    }

    IEnumerator StarStamp()
    {
        if (Player.Instance.inkLeft > 0.1f)
            StarAniamtion(0);

        yield return starCool;

        if (Player.Instance.inkLeft > 0.33f)
            StarAniamtion(1);

        yield return starCool;

        if (Player.Instance.inkLeft > 0.5f)
            StarAniamtion(2);
    }

    private void StarAniamtion(int n)
    {
        star[n].gameObject.SetActive(true);
        star[n].transform.DOScale(1f, 0.4f).SetEase(Ease.InBack);
    }

    private void SetStarDefault(int n)
    {
        star[n].gameObject.SetActive(false);
        star[n].transform.localScale = new Vector3(2, 2, 1);
    }
}
