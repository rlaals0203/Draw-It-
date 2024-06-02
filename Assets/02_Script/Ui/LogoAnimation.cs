using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class LogoAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool isOnMouseAnim = true;
    [SerializeField] private float maxRotate = 10;
    [SerializeField] private float moveTime = 2;

    private void Start()
    {
        StartCoroutine(ImageAnimation());
    }

    private void OnMouseAnimation()
    {
        if (isOnMouseAnim)
            transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutElastic);
    }

    private void ExitMouseAnimation()
    {
        if (isOnMouseAnim)
            transform.DOScale(1f, 0.25f).SetEase(Ease.OutCubic);
    }

    private IEnumerator ImageAnimation()
    {
        while (true)
        {
            transform.DORotate(new Vector3(0, 0, maxRotate), moveTime).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(moveTime);

            transform.DORotate(new Vector3(0, 0, -maxRotate), moveTime).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(moveTime);
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
