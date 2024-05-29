using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Shop : MonoBehaviour
{
    private bool[] isPurchased = new bool[9];
    private int[] price = new int[9];

    private void Start()
    {
        for (int i = 0; i < isPurchased.Length - 1; i++)
            isPurchased[i] = false;

        for (int i = 0; i < price.Length - 1; i++)
            price[i] = 100;

        StatManager.Instance.AddStar(1000);
    }

    public void OnItemClicked()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        int star = StatManager.Instance.GetStar();
        int index = int.Parse(button.name.Substring(4, 1)) - 1;

        if (star >= price[index] && !isPurchased[index])
        {
            StatManager.Instance.RemoveStar(price[index]);
            GameObject.Find(button.name).GetComponentInChildren<TMP_Text>().text = "소유중";

            Player.Instance.skinName = button.transform.parent.name;
            isPurchased[index] = true;

            Debug.Log(GameObject.Find(button.name).GetComponentInChildren<TMP_Text>().name);
            Debug.Log($"{Player.Instance.skinName} 스킨 구매 완료 남은 금액 : {StatManager.Instance.star}");
        }
        else
        {
            return;
            Debug.Log("잔액부족");
        }
    }
}
