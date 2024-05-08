using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButton : MonoBehaviour
{
    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnPlayClick()
    {
        MoveDown();
    }

    public void OnTutorialClick()
    {
        MoveRight();
    }

    public void OnShopClick()
    {
        MoveLeft();
    }

    public void OnStageClick()
    {
        MoveDown();
    }

    public void OnStageBack()
    {
        MoveUp();
    }

    public void OnShopBack()
    {
        MoveRight();
    }

    public void OnTutorialBack()
    {
        MoveLeft();
    }

    private void MoveDown()
    {
        transform.DOMove(new Vector2(transform.position.x, transform.position.y + 1080), 0.75f).SetEase(Ease.OutCirc);
    }

    private void MoveUp()
    {
        transform.DOMove(new Vector2(transform.position.x, transform.position.y - 1080), 0.75f).SetEase(Ease.OutCirc);
    }

    private void MoveRight()
    {
        transform.DOMove(new Vector2(transform.position.x - 1920, transform.position.y), 0.75f).SetEase(Ease.OutCirc);
    }

    private void MoveLeft()
    {
        transform.DOMove(new Vector2(transform.position.x + 1920, transform.position.y), 0.75f).SetEase(Ease.OutCirc); ;
    }
}
