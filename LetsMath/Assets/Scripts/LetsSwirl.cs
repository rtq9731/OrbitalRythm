using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsSwirl : MonoBehaviour
{
    [SerializeField] GameObject circlePrefab = null;
    [SerializeField] float swirlPower = 10f;
    [SerializeField] float radius = 30f;
    [SerializeField] LineRenderer lr = null;

    List<List<GameObject>> circles = new List<List<GameObject>>()
    {
        new List<GameObject>(),
        new List<GameObject>(),
        new List<GameObject>(),
        new List<GameObject>(),
        new List<GameObject>()
    };

    float timer = 0f;

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 360; j++)
            {
                circles[i].Add(Instantiate<GameObject>(circlePrefab, transform));
            }
        }
    }

    private void Start()
    {
        StartCoroutine(GetSwirl());
    }

    IEnumerator GetSwirl()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            for (int j = 0; j < circles[i].Count; j++)
            {
                circles[i][j].transform.position = new Vector2(Mathf.Cos(j * Mathf.Deg2Rad + (i * swirlPower) * Mathf.Deg2Rad), Mathf.Sin(j * Mathf.Deg2Rad + (i * swirlPower) * Mathf.Deg2Rad)) * ( i + 1 ) * radius;
                yield return new WaitForSeconds(0.00001f);
            }
        }

        int curNum = 0;
        for (int i = 0; i < 360; i++)
        {
            lr.SetPosition(curNum, Vector2.zero);
            curNum++;

            for (int j = 0; j < 5; j++)
            {
                lr.SetPosition(curNum, circles[j][i].transform.position);
                yield return new WaitForSeconds(0.00001f);
                curNum++;
            }

            for (int j = 4; j >= 0; j--)
            {
                lr.SetPosition(curNum, circles[j][i].transform.position);
                yield return new WaitForSeconds(0.00001f);
                curNum++;
            }
        }

        yield return null;
    }
}
