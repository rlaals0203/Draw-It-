using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private bool[] isPurchased = new bool[9];
    private int[] price = new int[9];

    [SerializeField] TMP_Text description;
    [SerializeField] RawImage skinImage;
    [SerializeField] Texture[] skinList;

    private TMP_Text prevSkin;

    public static string skinName;

    private string[] dialogue =
    {
        "���� �⺻���� �� ��Ų�̴� Ư���� ������ �ʴ´�",
        "���踦 �ؾ��ϴ� �� ��Ų�̴�..",
        "�̰��� �����ΰ�... ������ ������� �� ��Ų�̴�...",
        "ü���� �ξ�� �� �� ����..!",
        "PPT ������� �־������ �� ��Ų�̴�.",
        "����Ŭ ������ �ȰŰ��� �� ���..!",
        "",
        "ī���� ��Ż~ ���ϴ��� �۾�~ ���� �� �� ���̺���~",
        "���� �ְ��� �� ��Ų�̴�. ���� �ְ��ڸ��� ������ �ִ�.",
    };

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

    private void Start()
    {
        for (int i = 0; i < isPurchased.Length - 1; i++)
            isPurchased[i] = false;

        for (int i = 0; i < price.Length - 1; i++)
            price[i] = 100;
    }

    public void OnItemClicked()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        int index = int.Parse(button.name.Substring(4, 1)) - 1;

        ChangeInfo(index);

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

        Debug.Log(skinName);
    }

    private void Purchase(int index, GameObject button)
    {
        if (prevSkin != null)
            prevSkin.text = "������";

        StatManager.Instance.RemoveStar(price[index]);
        TMP_Text currentSkin = GameObject.Find(button.name).GetComponentInChildren<TMP_Text>();

        currentSkin.text = "������";

        prevSkin = currentSkin;
        skinName = button.transform.parent.name;
        isPurchased[index] = true;
    }

    private void Equip(GameObject button)
    {
        TMP_Text currentSkin = GameObject.Find(button.name).GetComponentInChildren<TMP_Text>();
        skinName = button.transform.parent.name;

        prevSkin.text = "������";
        currentSkin.text = "������";

        prevSkin = currentSkin;
    }

    private void ChangeInfo(int index)
    {
        description.text = dialogue[index];
        skinImage.texture = skinList[index];
    }
}