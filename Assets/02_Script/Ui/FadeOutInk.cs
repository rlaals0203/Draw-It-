using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutInk : MonoBehaviour
{
    [SerializeField] private GameObject slider;


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        print(hit.collider);
        if (hit.collider.tag == "FadeOutInk" && hit.collider != null)
        {
            slider.SetActive(false);
        }
        else
        {
            slider.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FadeOutInk"))
        {
            slider.SetActive(false);
        }
        else
        {
            slider.SetActive(true);
        }
    }
}
