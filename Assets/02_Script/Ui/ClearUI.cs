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

    [SerializeField] private RawImage star1;
    [SerializeField] private RawImage star2;
    [SerializeField] private RawImage star3;

    [SerializeField] private RawImage Bstar1;
    [SerializeField] private RawImage Bstar2;
    [SerializeField] private RawImage Bstar3;

    [SerializeField] private ParticleSystem starParticle;

    WaitForSeconds starCool;

    private bool isEnable = false;
    private bool isNext = false;

    private Vector3 startPos;

    private void Awake()
    {
        starCool = new WaitForSeconds(0.75f);
    }

    private void Start()
    {
        startPos = clearUI.transform.position;
        StartCoroutine(ClearUIDown());
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

        clearUI.transform.DOMove(new Vector3(startPos.x, startPos.y, startPos.z), 0.75f);

        yield return new WaitForSeconds(0.75f);

        background.gameObject.SetActive(false);

        if (isNext)
            NextStage();
    }

    IEnumerator StarStamp()
    {
        StarAniamtion(star1, Bstar1);

        yield return new WaitForSeconds(0.3f);

        Instantiate(starParticle, star1.transform.position, Quaternion.identity);

        yield return starCool;

        StarAniamtion(star2, Bstar2);

        yield return new WaitForSeconds(0.3f);

        Instantiate(starParticle, star2.transform.position, Quaternion.identity);

        yield return starCool;

        StarAniamtion(star3, Bstar3);

        yield return new WaitForSeconds(0.3f);

        Instantiate(starParticle, star3.transform.position, Quaternion.identity);
    }

    private void StarAniamtion(RawImage star, RawImage Bstar)
    {
        star.gameObject.SetActive(true);
        Bstar.gameObject.SetActive(true);
        star.transform.DOScale(1f, 0.3f).SetEase(Ease.InExpo);
        Bstar.transform.DOScale(1f, 0.3f).SetEase(Ease.InExpo);
    }
}
