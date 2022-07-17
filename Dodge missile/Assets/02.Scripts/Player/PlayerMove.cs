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
    }

    private void UpdateAcceleration()
    {
        velocity = rigid.velocity;

        velocity += input.horizontalInput * (Vector2)transform.right * Time.deltaTime * GameManager.Instance.timeScale * acceleration;
        velocity += input.verticalInput * (Vector2)transform.up * Time.deltaTime * GameManager.Instance.timeScale * acceleration;

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
