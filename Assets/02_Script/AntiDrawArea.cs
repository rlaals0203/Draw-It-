using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDrawArea : MonoBehaviour
{
    static public bool isAntiArea = false;

    public LayerMask layerMask;

    [SerializeField] private float _radius = 0.5f;

    private Vector3 _mousePos;

    private Collider2D[] _collectArray;

    private void FixedUpdate()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;

        Collider2D collider = Physics2D.OverlapCircle(_mousePos, _radius, layerMask);

        if (collider)
        {
            if (collider.CompareTag("AntiDrawArea") && collider != null)
            {
                isAntiArea = true;
            }
        }
        else
        {
            isAntiArea = false;
        }
    }
}
