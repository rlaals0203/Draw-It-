using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkLimit : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = new Vector3(Mathf.Clamp(Player.Instance.inkLeft, 0f, 1f), 1f, 1f);

        transform.GetComponent<RawImage>().color = Color.HSVToRGB(Mathf.Clamp
            (Player.Instance.inkLeft / 3.6f, 0, 100), 0.75f, 1);
    }
}
