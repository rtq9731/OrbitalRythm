using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : LootObj
{
    bool isEat = false;

    int cost = 1;

    protected override void OnEat(Transform target)
    {
        if (isEat) return;

        isEat = true;

        StartCoroutine(MoveToPlayer(target, 1f));
    }

    private IEnumerator MoveToPlayer(Transform target, float timeToTarget)
    {
        Vector2[] points;

        float timer = 0f;

        points = Utill.GetNearPointsToTarget(transform.position, target);
        points[0] = transform.position;

        while (target.gameObject.activeSelf && Vector2.Distance(points[3], transform.position) >= 0.01f)
        {
            timer += Time.deltaTime * GameManager.Instance.timeScale;

            points[3] = target.position;

            transform.position = Utill.GetBezierPoint(timer / timeToTarget, points);

            yield return null;
        }

        target.GetComponent<PlayerInven>().GetItem(cost);

        isEat = false;
        transform.gameObject.SetActive(false);
    }
}
