using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    public float inkLimitOrigin = 1;
    public float inkLimit = 1;
    public float inkLeft = 0;

    public bool isComplete = false;
    public bool isReset = false;
    public bool isEnoughInk = true;
    public bool isStart = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

        rb = GetComponent<Rigidbody2D>();

        OnInfLimitChange();
    }

    private void Update()
    {
        inkLeft = inkLimit / inkLimitOrigin;
        if (inkLimit <= 0)
        {
            isEnoughInk = false;
        }
        else
            isEnoughInk = true;

        if (transform.position.y < -10)
        {
            ResetPlayer();
            isReset = true;
            isStart = false;
            inkLimit = inkLimitOrigin;
            Portal.count = 1;
        }
    }   

    private void ResetPlayer()
    {
        rb.simulated = false;
        rb.velocity = new Vector2(0, 0);
        transform.position = GameObject.Find("PlayerPosition").transform.position;
        isReset = false;
    }

    private void OnInfLimitChange()
    {
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
            transform.position = new Vector2(0, -10);
        }
    }
}
