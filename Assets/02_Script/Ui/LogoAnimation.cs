using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class LogoAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private void Start()
    {
        StartCoroutine(ImageAnimation());
    }

    private void OnMouseAnimation()
    {
        transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutElastic);
    }

    private void ExitMouseAnimation()
    {
        transform.DOScale(1f, 0.25f).SetEase(Ease.OutCubic);
    }

    private IEnumerator ImageAnimation()
    {
        while (true)
        {
            transform.DORotate(new Vector3(0, 0, 10), 2f).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(2f);

            transform.DORotate(new Vector3(0, 0, -10), 2f).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(2f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseAnimation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ExitMouseAnimation();
    }
}
