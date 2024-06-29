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
        "마우스를 꾹 눌러 선을 그릴수 있습니다. 공이 목적지까지 갈 수 있도록 선을 그려보세요",
        "R을 누르거나 뒤로가기 버튼을 눌르면 그린 선을 되돌릴 수 있습니다.",
        "오른쪽 위에 있는 시작버튼을 누르면 공에 대한 중력이 적용되며 시작할 수 있습니다. 이후 한번 더 누르면 리셋할 수 있습니다.",
        "위쪽에 잉크량이 표시되며 잉크량을 모두 쓰게되면 더이상 선을 그을수 없게 됩니다.",
        "또한 남은 잉크량에 따라 별을 받을수 있으니 잉크량 관리를 잘해 많은 별을 모아보세요!."
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
