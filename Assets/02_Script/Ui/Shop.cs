using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Shop : MonoBehaviour
{
    private bool[] isPurchased = new bool[9];
    private int[] price = new int[9];

    string itemName;

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
        int star = StatManager.Instance.GetStar();
        GameObject button = EventSystem.current.currentSelectedGameObject;
        int n = int.Parse(button.name) - 1;
        Debug.Log(star);

        if (star >= price[n] && !isPurchased[n])
        {
            StatManager.Instance.RemoveStar(price[n]);
            GameObject.Find(button.name).GetComponentInChildren<TMP_Text>().text = "소유중";

            itemName = button.transform.parent.name;
            isPurchased[n] = true;

            Debug.Log($"{itemName} 스킨 구매 완료 남은 금액 : {StatManager.Instance.star}");
        }
        else
        {
            return;
            Debug.Log("잔액부족");
        }
    }
}
