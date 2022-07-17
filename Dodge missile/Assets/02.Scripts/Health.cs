using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHitable
{
    [SerializeField] int _maxHp = 30;

    protected int _hp = 0;

    protected virtual void Awake()
    {
        _hp = _maxHp;
    }

    public virtual void OnHit(int damage)
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
