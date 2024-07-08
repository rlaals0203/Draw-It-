using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDrawArea : MonoBehaviour
{
    public LayerMask layerMask;

    [SerializeField] private float _radius = 0.5f;

    private Vector3 _mousePos;

    private void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;

        Collider2D collider = Physics2D.OverlapCircle(_mousePos, _radius, layerMask);

        Debug.Log(collider || collider == null);

        if (collider)
        {
            if (collider.CompareTag("AntiDrawArea"))
            {
                StageManager.Instance.isAntiDraw = true;
            }
        }
        else
        {
            StageManager.Instance.isAntiDraw = false;
        }
    }
}
