using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(RenderTexture))]
public class VideoTutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text pageText;
    [SerializeField] private RawImage video;
    [SerializeField] private RenderTexture[] videos;

    private int count = 0;

    private void Awake()
    {
        videos = GetComponentsInChildren<RenderTexture>();
        video = GetComponent<RawImage>();

        ChangeVideo();
    }

    private string[] dialogue =
    {
        "���콺�� �� ���� ���� �׸��� �ֽ��ϴ�. ���� ���������� �� �� �ֵ��� ���� �׷�������",
        "R�� �����ų� �ڷΰ��� ��ư�� ������ �׸� ���� �ǵ��� �� �ֽ��ϴ�.",
        "������ ���� �ִ� ���۹�ư�� ������ ���� ���� �߷��� ����Ǹ� ������ �� �ֽ��ϴ�. ���� �ѹ� �� ������ ������ �� �ֽ��ϴ�.",
        "���ʿ� ��ũ���� ǥ�õǸ� ��ũ���� ��� ���ԵǸ� ���̻� ���� ������ ���� �˴ϴ�.",
        "���� ���� ��ũ���� ���� ���� ������ ������ ��ũ�� ������ ���� ���� ���� ��ƺ�����!."
    };

    public void OnSkipCliick()
    {
        count++;

        if (count >= videos.Length)
            count = 0;

        ChangeVideo();
    }

    public void GoBack()
    {
        count = 0;
        ChangeVideo();
    }

    private void ChangeVideo()
    {
        pageText.text = $"{count + 1}/{videos.Length}";
        dialogueText.text = dialogue[count];
        video.texture = videos[count];
    }
}
