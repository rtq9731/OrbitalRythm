using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public virtual void Play()
    {
        gameObject.SetActive(true);

        StartCoroutine(EffectCor());
    }

    protected virtual IEnumerator EffectCor()
    {
        ps.Play();

        yield return new WaitWhile(() => ps.isPlaying);

        gameObject.SetActive(false);
    }
}
