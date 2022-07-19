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

        Invoke("Test", 3f);
        Invoke("TestTwo", 9f);
    }

    private void Test()
    {
        SetUpdateHp(70);
    }

    private void TestTwo()
    {
        SetUpdateHp(40);
    }

    public void SetUpdateHp(int targetHP)
    {
        _targetHp = targetHP;

        StartCoroutine(UpdateImage());
    }

    private void Update()
    {
        RefreshColor();
    }

    private IEnumerator UpdateImage()
    {
        Debug.Log("��������");
        float timer = 0f;

        while (_fillImage.fillAmount >= _targetHp / 100)
        {
            _fillImage.fillAmount = Mathf.Lerp(_fillImage.fillAmount, _targetHp / 100, timer);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;

        yield return new WaitForSeconds(1f);

        Debug.Log(_fillLookImage.fillAmount);
        while (_fillLookImage.fillAmount >= _targetHp / 100)
        {
            _fillLookImage.fillAmount = Mathf.Lerp(_fillLookImage.fillAmount, _targetHp / 100, timer);
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
