using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutInk : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    private bool isPlayerEntered = false;

    private Vector3 _mousePos;

    void Update()
    {
        MousePosRay();
        SetFade();
    }

    private void MousePosRay()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, Mathf.Infinity);

        if (hit)
        {
            if (hit.collider.CompareTag("FadeOutInk"))
            {
                isPlayerEntered = true;
            }
            else
            {
                isPlayerEntered = false;
            }
        }
        else
        {
            isPlayerEntered = false;
        }
    }

    private void SetFade()
    {
        if (isPlayerEntered)
            slider.SetActive(false);
        else
            slider.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerEntered = false;
    }
}
