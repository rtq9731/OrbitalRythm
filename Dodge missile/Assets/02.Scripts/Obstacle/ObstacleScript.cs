using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : Health
{
    [SerializeField] Sprite[] _sprites = null;

    SpriteRenderer _sr = null;
    public Rigidbody2D rigid = null;

    public int _tier = 1;

    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            float speed = rigid.velocity.magnitude;

            rigid.velocity = Vector2.Reflect(rigid.velocity.normalized, collision.contacts[0].normal) * speed;
        }
    }

    public void InitObstacle(int tier, int hp, float speed, Vector2 dir, Vector2 point)
    {
        _hp = hp;
        _tier = tier;
        transform.position = point;

        gameObject.SetActive(true);

        if(_sr == null)
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        _sr.sprite = _sprites[Random.Range(0, _sprites.Length)];

        transform.localScale = new Vector3(tier, tier, tier);
        rigid.velocity = dir * speed;
    }

    public override void OnDie()
    {
        gameObject.SetActive(false);

        FindObjectOfType<ResourceGenerator>().GenerateResource(transform.position, _tier);

        if(_tier > 1)
        {
            FindObjectOfType<ObstacleGenerator>().SpawnObstacle(_tier - 1, transform.position);
            FindObjectOfType<ObstacleGenerator>().SpawnObstacle(_tier - 1, transform.position);
        }
    }
    
}
