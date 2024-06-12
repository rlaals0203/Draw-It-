using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 2.5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SuperJump"))
        {
            rb.velocity = new Vector2(rb.velocity.x / 1.25f, 0);
            rb.AddForce(collision.transform.up * Time.deltaTime  * jumpPower, ForceMode2D.Impulse);
            AudioManager.PlaySound(SoundType.JUMP);
        }
    }
}
