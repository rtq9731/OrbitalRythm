using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public void InitMissile(Vector2 normal, Vector3 startPos, Transform target, float timeToTarget, int damage)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg);
        transform.position = startPos;
        gameObject.SetActive(true);
        StartCoroutine(FireToTarget(target, timeToTarget, damage));
    }

    IEnumerator FireToTarget(Transform target, float timeToTarget, int damage)
    {
        Vector2 dir, targetOffset;
        Vector2[] points;

        EffectScript lockOnEffect, explosionEffect;

        float timer = 0f;

        points = GetNearPointsToTarget(target);
        points[0] = transform.position;

        targetOffset = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

        lockOnEffect = EffectManager.Instance.GetEffect("Missile_LockOn");

        lockOnEffect.transform.position = (Vector2)target.position + targetOffset;
        lockOnEffect.Play();

        while (target.gameObject.activeSelf && Vector2.Distance(points[3], transform.position) >= 0.01f)
        {
            timer += Time.deltaTime * GameManager.Instance.timeScale;

            points[3] = (Vector2)target.position + targetOffset;
            lockOnEffect.transform.position = points[3];

            transform.position = GetBezierPoint(timer / timeToTarget, points);

            dir = (GetBezierPoint(timer + 0.01f / timeToTarget, points) - (Vector2)transform.position).normalized;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);

            yield return null;
        }

        explosionEffect = EffectManager.Instance.GetEffect("Missile_Explosion");

        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();

        target.GetComponent<IHitable>().OnHit(damage);

        transform.gameObject.SetActive(false);
    }

    private Vector2 GetBezierPoint(float timing, Vector2[] points)
    {
        return Vector2.Lerp(Vector2.Lerp(Vector2.Lerp(points[0], points[1], timing), Vector2.Lerp(points[1], points[2], timing), timing), Vector2.Lerp(Vector2.Lerp(points[1], points[2], timing), Vector2.Lerp(points[2], points[3], timing), timing), timing);
    }

    private Vector2[] GetNearPointsToTarget(Transform target)
    {
        Vector2[] points = new Vector2[4]; 
        float[] timings = new float[4]{ 0, 0, 0, 1 }; // 근처 점을 뽑아올 직선 상의 위치비 ( ex 0.5 -> 중간점 )

        for (int i = 1; i < 3; i++)
        {
            timings[i] = Random.Range(0, 1);
        }

        for (int i = 0; i < 4; i++)
        {
            Vector2 point = Vector2.Lerp(transform.position, target.position, timings[i]);
            points[i] = point;
        }

        for (int i = 1; i < 3; i++)
        {
            points[i].x += Random.Range(-5, 5);
            points[i].y += Random.Range(-5, 5);
        }

        return points;
    }
}
