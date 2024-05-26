using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutInk : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    private bool isPlayerEntered = false;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if ((hit.collider.tag == "FadeOutInk" && hit.collider != null) || isPlayerEntered)
        {
            slider.SetActive(false);
        }
        else if (hit.collider.tag == "Background")
        {
            slider.SetActive(true);
        }
        else
        {
            slider.SetActive(true);
        }
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
