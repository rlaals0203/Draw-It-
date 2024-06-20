using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDrawArea : MonoBehaviour
{
    static public bool isAntiArea = false;
    static public bool isDrawableArea = false;

    private Vector3 _mousePos;

    private void Update()
    {
        MousePosRay();
    }

    private void MousePosRay()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, Mathf.Infinity);

        if (hit)
        {
            if (hit.collider.CompareTag("Block") || hit.collider.CompareTag("AntiDrawArea"))
            {
                isAntiArea = true;
            }
            else
            {
                isAntiArea = false;
            }
        }
        else
        {
            isAntiArea = false;
        }
    }
}
