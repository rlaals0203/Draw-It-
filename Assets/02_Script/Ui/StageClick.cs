using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClick : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void OnButtonClick() //button points to this
    {
        StageManager.Instance.OnStageClick();
    }
}
