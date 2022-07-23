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

        points = Utill.GetNearPointsToTarget(transform.position, target);
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

            transform.position = Utill.GetBezierPoint(timer / timeToTarget, points);

            dir = (Utill.GetBezierPoint(timer + 0.01f / timeToTarget, points) - (Vector2)transform.position).normalized;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);

            yield return null;
        }

        explosionEffect = EffectManager.Instance.GetEffect("Missile_Explosion");

        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();

        target.GetComponent<IHitable>().OnHit(damage);

        transform.gameObject.SetActive(false);
    }

}
