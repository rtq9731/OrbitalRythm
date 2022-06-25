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
        Debug.Log(new Vector2(Mathf.Sin(360), Mathf.Cos(360)));
        transform.position = new Vector2(0, 11);

        timer.onTimerSet += () => gameObject.SetActive(true);
    }

    void Update()
    {
        if (timer.GameTime <= 0)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isInner = !isInner;
        }

        transform.position = new Vector2 (Mathf.Sin(timer.GameTime % 360f) * (10 + (isInner ? 1f : -1f)), Mathf.Cos(timer.GameTime % 360f) * (10 + (isInner ? 1f : -1f)));

        Vector3 dir = (new Vector3(Mathf.Sin((timer.GameTime + 0.1f)% 360f) * (10 + (isInner ? 1f : -1f)), Mathf.Cos((timer.GameTime + 0.1f) % 360f) * (10 + (isInner ? 1f : -1f))) - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);
    }
}
