using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    public float inkLimitOrigin = 1;
    public float inkLimit = 1;
    public float inkLeft = 0;

    public string skinName = " ";

    public bool isComplete = false;
    public bool isEnoughInk = true;
    public bool isStart = false;
    public bool isReset = false;
    public bool isCompleteAnimEnd = true;

    private Rigidbody2D rb;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

        rb = GetComponent<Rigidbody2D>();

        ChangeInkLimit();
    }

    private void Update()
    {
        inkLeft = inkLimit / inkLimitOrigin;

        if (inkLeft <= 0)
        {
            isEnoughInk = false;
        }
        else
            isEnoughInk = true;


        if (transform.position.y < -10 || isReset)
        {
            ResetPlayer();
        }

        if (isComplete)
        {
            StageManager.Instance.SetMaxInk();
        }
    }   

    public void ResetPlayer()
    {
        isComplete = false;
        isReset = true;
        isStart = false;

        inkLimit = inkLimitOrigin;

        rb.velocity = Vector2.zero;
        rb.freezeRotation = false;
        rb.simulated = false;

        transform.position = GameObject.Find("PlayerPosition").transform.position;
    }

    private void ChangeInkLimit()
    {
        inkLimitOrigin = StageManager.Instance.GetInkLimit();
        inkLimit = inkLimitOrigin;
        inkLimit = Mathf.Clamp(inkLimit, 0, inkLimitOrigin);
    }

    private IEnumerator DecelerationVelocity()
    {
        for (int i = 0; i < 10; i++)
        {
            rb.velocity /= 1.5f;
            yield return new WaitForSeconds(0.1f);
        }

        rb.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StageEnd" && !isComplete)
        {
            StageManager.Instance.stageComplete[StageManager.Instance.currentLevel - 1] = true;
            isComplete = true;

            StartCoroutine(DecelerationVelocity());
            AudioManager.PlaySound(SoundType.COMPLETE);
        }

        if (collision.tag == "Gear")
        {
            ResetPlayer();
        }
    }
}
