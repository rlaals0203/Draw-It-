using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static int count = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PortalEnter")
        {
            GameObject portal = GameObject.Find($"PortalOut{count}");
            transform.position = portal.transform.position;
            count++;
        }
    }
}
