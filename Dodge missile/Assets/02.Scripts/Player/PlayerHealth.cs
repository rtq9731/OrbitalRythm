using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    bool canHit = true;

    [SerializeField] ValueBarScript hpBar = null;
    [SerializeField] float shockWavePower = 4f;

    SpriteRenderer sr = null;
    WaitForSeconds ws = new WaitForSeconds(0.5f);

    protected override void Awake()
    {
        base.Awake();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && canHit)
        {
            OnHit(collision.gameObject.GetComponent<ObstacleScript>()._tier * 5, collision.transform);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && canHit)
        {
            OnHit(collision.gameObject.GetComponent<ObstacleScript>()._tier * 5, collision.transform);
        }
    }

    public void OnHit(int damage, Transform obstacle)
    {

        hpBar.SetUpdateValue(damage);

        StartCoroutine(hitEffect());

        base.OnHit(damage);
    }

    IEnumerator hitEffect()
    {
        canHit = false;

        for (int i = 0; i < 5; i++)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            yield return ws;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            yield return ws;
        }

        canHit = true;

        yield return null;
    }
}
