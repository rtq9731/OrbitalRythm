using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircleMove : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    bool isInner = false;

    [SerializeField] GameTimer timer = null;

    private void Awake()
    {
        transform.position = new Vector2(0, 11);

        timer.onTimerSet += () => gameObject.SetActive(true);
    }

    void Update()
    {
        if (timer.GameTime <= 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isInner = !isInner;
        }

        Move();
    }

    private void Move()
    {
        Vector2 posVector = GetCirclePos(timer.GameTime);

        transform.position = new Vector2(posVector.x, posVector.y);

        Vector3 dir = (new Vector3(GetCirclePos(timer.GameTime + 0.1f).x, GetCirclePos(timer.GameTime + 0.1f).y) - transform.position).normalized;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);
    }

    private Vector2 GetCirclePos(float t)
    {
        Vector2 result = Vector2.zero;

        result.x = Mathf.Sin(t) * (10 + (isInner ? 1f : -1f));
        result.y = Mathf.Cos(t) * (10 + (isInner ? 1f : -1f));

        return result;
    }
}
