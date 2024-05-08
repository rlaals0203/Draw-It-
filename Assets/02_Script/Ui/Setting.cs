using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    static public bool isSettingOpen = false;

    [SerializeField] private GameObject settingUI;

    [SerializeField] private TMP_InputField bgm_Input;
    [SerializeField] private TMP_InputField sfx_Input;

    [SerializeField] private Slider bgm_Slider;
    [SerializeField] private Slider sfx_Slider;

    private void Start()
    {
        settingUI.SetActive(false);
    }
    private void Update()
    {
        bgm_Input.text = Mathf.RoundToInt(bgm_Slider.value * 100).ToString();
        sfx_Input.text = Mathf.RoundToInt(sfx_Slider.value * 100).ToString();
    }

    public void OnSettingOpen()
    {
        isSettingOpen = !isSettingOpen;
        settingUI.SetActive(isSettingOpen);
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
