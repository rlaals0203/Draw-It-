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
    [SerializeField] private GameObject currencyUI;

    [SerializeField] private TMP_Text inkLeftUI;
    [SerializeField] private TMP_Text starText;

    [SerializeField] private RawImage[] star;

    WaitForSeconds starCool;

    private bool isEnable = false;
    private bool isNext = false;

    private Vector3 clearUIStartPos;
    private Vector3 currencyUIStartPos;

    private void Awake()
    {
        starCool = new WaitForSeconds(0.6f);
    }

    private void Start()
    {
        clearUIStartPos = clearUI.transform.position;
        currencyUIStartPos = currencyUI.transform.position;

        starText.text = StatManager.Instance.star.ToString();
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
            StartCoroutine(ClearUIActive());
        }

        inkLeftUI.text = $"³²Àº À×Å©·® : {Mathf.Round(Mathf.Abs(Player.Instance.inkLeft * 100)),4}%";
    }

    public void PlayAgain()
    {
        Player.Instance.isReset = true;
        StartCoroutine(ClearUIUnactive());
    }

    public void NextStageClick()
    {
        isNext = true;
        StartCoroutine(ClearUIUnactive());
    }

    private void NextStage()
    {
        isNext = false;
        StageManager.Instance.NextStage();
        Player.Instance.ResetPlayer();
    }

    IEnumerator ClearUIActive()
    {
        Player.Instance.isCompleteAnimEnd = false;
        background.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        background.DOFade(0.8f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        ActiveUIMove();

        yield return new WaitForSeconds(1f);

        StartCoroutine(StarStamp());
    }

    IEnumerator ClearUIUnactive()
    {
        background.DOFade(0f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        InActiveUIMove();

        yield return new WaitForSeconds(0.9f);

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

        if (Player.Instance.inkLeft > 0.333f)
            StarAniamtion(1);

        yield return starCool;

        if (Player.Instance.inkLeft > 0.5f)
            StarAniamtion(2);
    }

    private void StarAniamtion(int n)
    {
        star[n].gameObject.SetActive(true);
        star[n].transform.DOScale(1f, 0.4f).SetEase(Ease.InBack);
        Camera.main.transform.DOShakePosition(0.2f, 0.5f, 50, 50);
        clearUI.transform.DOShakePosition(0.2f, 50f, 50, 50);

        StatManager.Instance.AddStar(5);
        starText.text = StatManager.Instance.star.ToString();
    }

    private void SetStarDefault(int n)
    {
        star[n].gameObject.SetActive(false);
        star[n].transform.localScale = new Vector3(2, 2, 1);
    }

    private void ActiveUIMove()
    {
        clearUI.transform.DOMove(new Vector3(clearUI.transform.position.x, 550, clearUI.transform.position.z), 0.75f);
        currencyUI.transform.DOMove(new Vector3(1550, currencyUI.transform.position.y, clearUI.transform.position.z), 0.75f);
    }
    private void InActiveUIMove()
    {
        clearUI.transform.DOMove(new Vector3(clearUIStartPos.x, clearUIStartPos.y, clearUIStartPos.z), 0.75f).SetEase(Ease.InBack);

        currencyUI.transform.DOMove(new Vector3(currencyUIStartPos.x, currencyUIStartPos.y,
            currencyUIStartPos.z), 0.75f).SetEase(Ease.InBack);
    }
}
