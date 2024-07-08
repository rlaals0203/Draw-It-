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
        Shop.Instance.onSceneChange?.Invoke();
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

    public void MoveDown()
    {
        transform.DOMove(new Vector2(transform.position.x, transform.position.y + 1080), 0.75f).SetEase(Ease.InOutBack);
    }

    public void MoveUp()
    {
        transform.DOMove(new Vector2(transform.position.x, transform.position.y - 1080), 0.75f).SetEase(Ease.InOutBack);
    }

    private void MoveRight()
    {
        transform.DOMove(new Vector2(transform.position.x - 1920, transform.position.y), 0.75f).SetEase(Ease.InOutBack);
    }

    private void MoveLeft()
    {
        transform.DOMove(new Vector2(transform.position.x + 1920, transform.position.y), 0.75f).SetEase(Ease.InOutBack); ;
    }
}
