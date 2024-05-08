using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class StageCompleteAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text compText;
    [SerializeField] private ParticleSystem effect;
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    private bool isEnable = false;

    private void Update()
    {
        if (Player.Instance.isReset)
        {
            isEnable = false;
        }

        if (Player.Instance.isComplete && !isEnable)
        {
            StartCoroutine(textAnimation());
            isEnable = true;
        }
    }

    IEnumerator textAnimation()
    {
        yield return new WaitForSeconds(1f);

        compText.transform.DOScale(25, 1f).SetEase(Ease.OutBounce);
        StartCoroutine(GenerateParticleRoutine());
        yield return new WaitForSeconds(2.5f);

        compText.transform.DOScale(0, 0.2f);
    }

    IEnumerator GenerateParticleRoutine()
    {
        for (int i = 0; i < 20; i++)
        {
            GenerateParticle();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
    }

    private void GenerateParticle()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-6f, 6f), Random.Range(-4f, 4f));
        ParticleSystem particle = Instantiate(effect, spawnPos, Quaternion.identity);

        particle.startSize = Random.Range(0.25f, 2f);
        particle.startLifetime = Random.Range(0.3f, 1f);

        particles.Add(particle);

    }
}
