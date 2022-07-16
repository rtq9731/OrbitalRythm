using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float accelerationMax = 5f;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float angleOffset = 45f;

    Rigidbody2D rigid = null;
    Vector2 velocity = Vector2.zero;
    PlayerInput input = null;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        UpdateAcceleration();
        UpdateRotation();
        UpdateClamp();
    }

    private void UpdateClamp()
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

    private void UpdateAcceleration()
    {
        velocity = rigid.velocity;

        velocity += input.horizontalInput * (Vector2)transform.right * Time.deltaTime * acceleration;
        velocity += input.verticalInput * (Vector2)transform.up * Time.deltaTime * acceleration;

        velocity.x = Mathf.Clamp(velocity.x, -accelerationMax, accelerationMax);
        velocity.y = Mathf.Clamp(velocity.y, -accelerationMax, accelerationMax);

        rigid.velocity = velocity;
    }

    private void UpdateRotation()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
