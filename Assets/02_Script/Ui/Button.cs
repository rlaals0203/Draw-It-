using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject resetButton;

    private void Update()
    {
        if (Player.Instance.isReset)
        {
            StartButton();
        }
    }
    public void OnStartClick()
    {
        ResetButton();
        ball.GetComponent<Rigidbody2D>().simulated = true;
        Player.Instance.isStart = true;
        Portal.count = 1;
    }

    public void OnResetClick()
    {
        StartButton();
        Player.Instance.ResetPlayer();
    }

    private void StartButton()
    {
        startButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
    }

    private void ResetButton()
    {
        startButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
    }
}
