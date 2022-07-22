using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTimeScript : MonoBehaviour
{
    [SerializeField] float easingTime = 0.1f;

    [SerializeField] LineRenderer lr = null;

    [SerializeField] float lineRadius = 0.1f;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }


    private void OnClick()
    {
        StartCoroutine(ButtonClick());
    }

    IEnumerator ButtonClick()
    {
        float timer = 0f;
        while(timer <= easingTime)
        {
            transform.localScale = Vector3.one * Mathf.Lerp(1f, 0.75f, timer / easingTime);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;

        while (timer <= easingTime)
        {
            transform.localScale = Vector3.one * Mathf.Lerp(0.75f, 1f, timer / easingTime);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        DrawCoolLine();

        int curNum = 0;
        for (int i = 0; i < 360; i++)
        {
            lr.SetPosition(curNum, Vector3.zero);
            curNum++;
            lr.SetPosition(curNum, Vector3.zero);
            curNum++;
            lr.SetPosition(curNum, Vector3.zero);
            curNum++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void DrawCoolLine()
    {
        int curNum = 0;
        for (int i = 0; i < 360; i++)
        {
            lr.SetPosition(curNum, Vector3.zero);
            curNum++;
            lr.SetPosition(curNum, new Vector2(Mathf.Sin(i * Mathf.Deg2Rad), Mathf.Cos(i * Mathf.Deg2Rad)) * lineRadius);
            curNum++;
            lr.SetPosition(curNum, Vector3.zero);
            curNum++;
        }
    }
}
