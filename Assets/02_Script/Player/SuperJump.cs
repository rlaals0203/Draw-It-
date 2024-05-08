using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SuperJump"))
        {
            print("aaa");
            transform.GetComponent<Rigidbody2D>().AddForce(
                Vector2.up * Time.deltaTime  * jumpPower, ForceMode2D.Impulse);
        }
    }
}
