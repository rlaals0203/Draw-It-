using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject background;
    [SerializeField] private TMP_Text korean;
    [SerializeField] private TMP_Text english;

    private void Start()
    {
        StartCoroutine(IntroRoutine());
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
    }
}
