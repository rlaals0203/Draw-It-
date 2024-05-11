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
            ChangeUI(true);
        }
    }
    public void OnStartClick()
    {
        ChangeUI(false);
        ball.GetComponent<Rigidbody2D>().simulated = true;
        Player.Instance.isStart = true;
    }

    public void OnResetClick()
    {
        ChangeUI(true);
        Player.Instance.ResetPlayer();
    }

    private void ChangeUI(bool value)
    {
        startButton.gameObject.SetActive(value);
        resetButton.gameObject.SetActive(!value);
    }
}
