using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHsvColor : MonoBehaviour
{
    SpriteRenderer sr = null;

    float timer1, timer2, timer3;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        timer1 = 0f;
        timer2 = 0f;
        timer3 = 0f;
    }

    private void Update()
    {
        timer1 += Time.deltaTime * 3;
        timer2 += Time.deltaTime * 2;
        timer3 += Time.deltaTime * 1;

        sr.color = Color.HSVToRGB(0.5f * Mathf.Sin(timer1) + 0.5f, 0.5f * Mathf.Sin(timer2) + 0.5f, 0.5f * Mathf.Sin(timer3) + 0.5f);
    }
}
