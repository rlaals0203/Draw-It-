using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public Sprite[] spriteList;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Player.Instance.isReset)
        {
            SetSkin();
        }
    }

    public void SetSkin()
    {
        foreach (Sprite sprite in spriteList)
        {
            if (sprite.name == Player.Instance.skinName)
            {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }
}
