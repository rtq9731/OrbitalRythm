using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : Health
{
    [SerializeField] Sprite[] _sprites = null;

    SpriteRenderer _sr = null;
    Rigidbody2D rigid = null;

    public int _tier = 1;

    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
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

        _velocity = dir * speed;
        transform.localScale = new Vector3(tier, tier, tier);
    }

    private void Update()
    {
        CalcMoving();
    }

    private void CalcMoving()
    {
        transform.Translate(_velocity * Time.deltaTime * GameManager.Instance.timeScale);
    }

    public override void OnDie()
    {
        gameObject.SetActive(false);

        if(_tier > 1)
        {
            FindObjectOfType<ObstacleGenerator>().SpawnObstacle(_tier - 1, transform.position);
            FindObjectOfType<ObstacleGenerator>().SpawnObstacle(_tier - 1, transform.position);
        }
    }
    
}
