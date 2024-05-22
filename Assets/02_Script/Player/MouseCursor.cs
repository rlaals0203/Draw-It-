using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursortex;

    private void Start()
    {
        setcursor();
    }

    private void setcursor()
    {
        Cursor.SetCursor(cursortex, new Vector2(cursortex.width * 0.5f, cursortex.height * 0.5f), CursorMode.Auto);
    }
}