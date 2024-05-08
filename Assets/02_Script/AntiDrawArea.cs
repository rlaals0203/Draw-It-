using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDrawArea : MonoBehaviour
{
    static public bool isAntiArea = false;
    

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Block" || hit.collider.tag == "AntiDrawArea")
            {
                isAntiArea = true;
            }
            else
                isAntiArea = false;
        }
        else
            isAntiArea = false;
    }
}
