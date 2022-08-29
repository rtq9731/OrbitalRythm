using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHitable
{
    [SerializeField] float _maxHp = 30;

    protected float _hp = 0;

    protected virtual void Awake()
    {
        _hp = _maxHp;
    }

    public virtual void OnHit(float damage)
    {
        if (!gameObject.activeSelf)
            return;

        _hp -= damage;

        if (_hp <= 0)
            OnDie();
    }

    public virtual void OnDie()
    {
        gameObject.SetActive(false);
    }
}
