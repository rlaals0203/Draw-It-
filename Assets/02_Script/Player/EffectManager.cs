using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem clearEffect;
    [SerializeField] private ParticleSystem jumpEffect;
    private bool ClearCoolTIme;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StageEnd") && !ClearCoolTIme)
        {
            ParticleSystem effect = Instantiate(clearEffect, transform.position, Quaternion.identity);
        }

        if (collision.CompareTag("SuperJump"))
        {
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
        }
    }
}
