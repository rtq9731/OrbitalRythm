using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    [SerializeField] Image _fillImage = null;
    [SerializeField] Image _fillLookImage = null;

    [SerializeField] float lerpTime = 0.5f;

    Coroutine cor = null;

    float _targetHp = 100f;

    private void Start()
    {
        RefreshColor();

        Invoke("Test", 1f);
        Invoke("Test", 2f);
        Invoke("Test", 3f);
        Invoke("Test", 4f);
    }

    private void Test()
    {
        SetUpdateHp(_targetHp - 10);
    }

    public void SetUpdateHp(float damage)
    {
        _targetHp = damage;

        if (cor != null)
            StopCoroutine(cor);

        cor = StartCoroutine(UpdateImage());
    }

    private void Update()
    {
        RefreshColor();
    }

    private IEnumerator UpdateImage()
    {
        float timer = 0f;

        while (lerpTime >= timer)
        {
            _fillImage.fillAmount = Mathf.Lerp(_fillImage.fillAmount, _targetHp / 100, timer / lerpTime);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;

        Debug.Log(_fillLookImage.fillAmount);
        while (lerpTime >= timer)
        {
            Debug.Log(timer / lerpTime);
            _fillLookImage.fillAmount = Mathf.Lerp(_fillLookImage.fillAmount, _targetHp / 100, timer / lerpTime);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    private void RefreshColor()
    {
        _fillImage.color = new Color(_fillImage.fillAmount != 0 ? 1f - _fillImage.fillAmount : 0f, _fillImage.fillAmount, 0);
        _fillLookImage.color = new Color(_fillLookImage.fillAmount != 0 ? 1f - _fillLookImage.fillAmount : 0f, _fillLookImage.fillAmount, 0, 0.2f);
    }

}
