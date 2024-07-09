using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    public TrailRenderer trail;

    public float inkLimitOrigin = 1;
    public static float inkLimit = Mathf.Clamp(inkLimit, 0f, 1f);
    public float inkLeft;

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
        trail = GetComponent<TrailRenderer>();

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
        trail.time = 0;
        transform.position = GameObject.Find("PlayerPosition").transform.position;

        isReset = true;
        isComplete = false;
        isStart = false;
        rb.freezeRotation = false;
        rb.simulated = false;

        inkLimit = inkLimitOrigin;

        rb.velocity *= 0;
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
        if (collision.tag == "StageEnd" && !isComplete && !isReset)
        {
            StageManager.Instance.stageComplete[StageManager.Instance.currentLevel - 1] = true;
            isCompleteAnimEnd = false;
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
