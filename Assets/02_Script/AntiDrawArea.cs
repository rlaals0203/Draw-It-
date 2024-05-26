using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDrawArea : MonoBehaviour
{
    static public bool isAntiArea = false;
    static public bool isDrawableArea = false;

    Ray2D ray;
    RaycastHit2D hit;

    private void Update()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider.tag == "Block" || hit.collider.tag == "AntiDrawArea")
        {
            isAntiArea = true;
        }
        else if (hit.collider.tag == "DrawableArea")
        {
            isDrawableArea = true;
        }
        else
        {
            isAntiArea = false;
            isDrawableArea = false;
        }
    }
}
