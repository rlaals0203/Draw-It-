using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

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
        "공이 목적지까지 갈 수 있게 드래그해 선을 그립니다.",
        "R을 누르거나 뒤로가기 버튼을 눌러 그린 선을 되돌릴 수 있습니다.",
        "오른쪽 위에 있는 시작버튼을 눌러 시작할 수 있습니다.",
        "잉크량을 모두 쓰게되면 더이상 선을 그을수 없습니다.",
        "또한 남은 잉크량에 따라 별을 받을수 있으니 잉크량 관리는 매우 중요합니다."
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
