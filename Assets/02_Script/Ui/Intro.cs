using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject intro;
    [SerializeField] private RawImage logo;
    [SerializeField] private RawImage background;
    [SerializeField] private TMP_Text korean;
    [SerializeField] private TMP_Text english;

    private void Start()
    {
        if (!StatManager.Instance.isPlayed)
        {
            StopAllCoroutines();
            intro.SetActive(true);
            StartCoroutine(IntroRoutine());
        }
        else
            return;
    }

    IEnumerator IntroRoutine()
    {
        logo.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1f);

        logo.transform.DOScale(6, 2f).SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(2f);

        logo.transform.DOScale(10, 1f).SetEase(Ease.InOutBack);

        yield return new WaitForSeconds(0.2f);

        logo.transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetEase(Ease.InOutCirc);

        yield return new WaitForSeconds(1.5f);

        logo.transform.DOScale(5, 1f).SetEase(Ease.InOutQuad);

        logo.transform.DOMove(new Vector3(logo.transform.position.x, logo.transform.position.y + 300, logo.transform.position.z), 1f).SetEase(Ease.InOutQuad);

        yield return new WaitForSeconds(1.25f);

        english.DOFade(1f, 0.5f);

        yield return new WaitForSeconds(1f);

        korean.DOFade(1f, 0.5f);

        yield return new WaitForSeconds(2.5f);

        english.DOFade(0, 2f);
        korean.DOFade(0, 2f);
        logo.DOFade(0, 2f);
        background.DOFade(0, 2f);

        yield return new WaitForSeconds(2f);

        intro.SetActive(false);

        StatManager.Instance.isPlayed = true;
    }
}
