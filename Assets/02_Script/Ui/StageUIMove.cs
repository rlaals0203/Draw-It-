using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageUIMove : MonoBehaviour
{
    private int currnetWorld = 1;
    [SerializeField] private GameObject[] world;

    public void OnRightArrowClick()
    {
        MoveRight();
    }

    public void OnLeftArrowClick()
    {
        MoveLeft();
    }

    private void MoveRight()
    {
        world[currnetWorld].transform.DOScale(1f, 0.5f);
        world[currnetWorld].transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);

        world[currnetWorld - 1].transform.DOScale(0.4f, 0.5f);
        world[currnetWorld - 1].transform.DOLocalMove(new Vector3(-1100, 0, 0), 0.5f);
    }

    private void MoveLeft()
    {
        world[currnetWorld - 1].transform.DOScale(1f, 0.5f);
        world[currnetWorld - 1].transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);

        world[currnetWorld].transform.DOScale(0.4f, 0.5f);
        world[currnetWorld].transform.DOLocalMove(new Vector3(1100, 0, 0), 0.5f);
    }
}
