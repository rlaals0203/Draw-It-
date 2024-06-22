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
        if (!Player.Instance.isStart)
        {
            SetSkin();
        }
    }

    public void SetSkin()
    {
        foreach (Sprite sprite in spriteList)
        {
            if (sprite.name == StageManager.Instance.currentSkin)
            {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }
}
