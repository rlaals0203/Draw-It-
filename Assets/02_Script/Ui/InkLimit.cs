using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkLimit : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = new Vector3(Mathf.Clamp((Player.Instance.inkLimit /
            Player.Instance.inkLimitOrigin), 0, 1), 1, 1);

        transform.GetComponent<RawImage>().color = Color.HSVToRGB(Mathf.Clamp((Player.Instance.inkLimit /
            Player.Instance.inkLimitOrigin) / 3.6f, 0, 100), 1, 1);
    }
}
