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

    private bool isEnable = false;
    private Vector3 startPos;

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
        Player.Instance.transform.position = new Vector2(0, -10);
        Player.Instance.isStart = false;
        StartCoroutine(ClearUIUp());
    }

    public void NextStage()
    {
        Player.Instance.isStart = false;
        StartCoroutine(ClearUIUp());
    }

    IEnumerator ClearUIDown()
    {
        background.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        background.DOFade(0.8f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        clearUI.transform.DOMove(new Vector3(clearUI.transform.position.x, 550, clearUI.transform.position.z), 0.75f);
    }

    IEnumerator ClearUIUp()
    {
        Player.Instance.isComplete = false;

        background.DOFade(0f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        clearUI.transform.DOMove(new Vector3(startPos.x, startPos.y, startPos.z), 0.75f);

        yield return new WaitForSeconds(0.5f);

        background.gameObject.SetActive(false);
    }
}
