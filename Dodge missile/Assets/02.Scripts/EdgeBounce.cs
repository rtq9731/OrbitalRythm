using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeBounce : MonoBehaviour
{
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f)
        {
            pos.x = 0f;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
        }
        if (pos.x > 1f)
        {
            pos.x = 1f;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.left * 3, ForceMode2D.Impulse);
        }
        if (pos.y < 0f)
        {
            pos.y = 0f;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        }
        if (pos.y > 1f)
        {
            pos.y = 1f;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.down * 3, ForceMode2D.Impulse);
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
