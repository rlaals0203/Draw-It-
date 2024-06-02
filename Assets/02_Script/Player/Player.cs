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
        isReset = true;
        isStart = false;

        inkLimit = inkLimitOrigin;
        rb.simulated = false;
        rb.velocity = new Vector3(0, 0, 0);

        transform.position = GameObject.Find("PlayerPosition").transform.position;
    }

    private void ChangeInkLimit()
    {
        inkLimitOrigin = StageManager.Instance.GetInkLimit();
        inkLimit = inkLimitOrigin;
        inkLimit = Mathf.Clamp(inkLimit, 0, inkLimitOrigin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StageEnd")
        {
            isComplete = true;
        }

        if (collision.tag == "Gear")
        {
            ResetPlayer();
        }
    }
}
