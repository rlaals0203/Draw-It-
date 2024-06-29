using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public UnityEvent onSceneChange;

    public static Shop Instance = null;
    [SerializeField] private bool[] isPurchased = new bool[9];
    [SerializeField] private int[] price = new int[9];

    [SerializeField] private TMP_Text description;
    [SerializeField] private RawImage skinImage;
    [SerializeField] private Texture[] skinList;

    private TMP_Text prevSkin;

    private int index = 0;
    private int equipSkin = 0;

    public static string skinName;

    private string[] dialogue =
    {
        "가장 기본적인 공 스킨, 띡히 특별해 보이진 않는다",
        "숭배를 해야하는 공 스킨이다..",
        "이것은 무엇인가... 왜인지 빠져드는 공 스킨이다...",
        "체스를 두어야 할 것 같아..!",
        "PPT 배경으로 넣어보고싶은 공 스킨이다.",
        "마이클 조던이 된거같은 이 기분..!",
        "톱니바퀴",
        "이것은 진품인가 가품인가..",
        "우주 최강의 공 스킨이다. 오직 최강자만이 가질수 있다.",
    };

    [SerializeField] private string[] skinPrefs = new string[10];

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        StageManager.Instance.SetStageButton();
        isPurchased[0] = true;
    }

    private void Update()
    {

    }

    private int star
    {
        get => StatManager.Instance.GetStar();

        set
        {
            if (star <= 0)
            {
                star = 0;
            }
            else
                star = value;
        }
    }

    public void OnItemClicked()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        index = int.Parse(button.name.Substring(4, 1)) - 1;

        ChangeInfo();

        if (isPurchased[index])
        {
            Equip(button);
            return;
        }
        else if (star >= price[index] && !isPurchased[index])
        {
            Purchase(index, button);
        }
        else
        {
            return;
        }

        //Debug.Log(skinName);
    }

    private void Purchase(int index, GameObject button)
    {
        AudioManager.PlaySound(SoundType.PURCHASE);

        if (prevSkin != null)
            prevSkin.text = "소유중";

        StatManager.Instance.RemoveStar(price[index]);
        TMP_Text currentSkin = GameObject.Find(button.name).GetComponentInChildren<TMP_Text>();

        currentSkin.text = "장착중";

        prevSkin = currentSkin;
        skinName = button.transform.parent.name;
        isPurchased[index] = true;

        PlayerPrefs.SetString($"Skin{index + 1}", "1");
    }

    private void Equip(GameObject button)
    {
        TMP_Text currentSkin = GameObject.Find(button.name).GetComponentInChildren<TMP_Text>();

        if (prevSkin != null)
            prevSkin.text = "소유중";

        currentSkin.text = "장착중";
        skinName = button.transform.parent.name;

        prevSkin = currentSkin;

        PlayerPrefs.SetInt("Equip", index + 1);
    }

    private void ChangeInfo()
    {
        description.text = dialogue[index];
        skinImage.texture = skinList[index];
    }

    public void LoadData()
    {
        for (int i = 1; i < 10; i++)
        {
            skinPrefs[i - 1] = PlayerPrefs.GetString($"Skin{i}");

            Debug.Log(skinPrefs[i]);

            if (skinPrefs[i - 1] == "1")
            {
                Debug.Log("aaaa");
                GameObject.Find($"Price{i}").GetComponent<TMP_Text>().text = "소유중";
                isPurchased[i - 1] = true;
            }
        }

        equipSkin = PlayerPrefs.GetInt("Equip");
        description.text = dialogue[equipSkin - 1];
        skinImage.texture = skinList[equipSkin - 1];
        GameObject.Find($"Price{equipSkin}").GetComponent<TMP_Text>().text = "장착중";
        skinName = skinList[equipSkin - 1].name;
        Debug.Log(skinName);
    }
}
