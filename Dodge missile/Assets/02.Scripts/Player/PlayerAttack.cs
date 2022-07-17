using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] MissileScript missilePrefab = null;

    [SerializeField] float coolBetweenAttack = 0.3f;
    [SerializeField] float missileCount = 3;
    [SerializeField] float missileSpeed = 1;
    [SerializeField] float attackCool = 1f;
    [SerializeField] int missileDamage = 1;

    [SerializeField] LayerMask whatIsEnemy;

    float attackCoolTimer = 0f;

    GenericPool<MissileScript> missilePool = null;

    WaitForSeconds waitForSeconds = null;

    PlayerInput input = null;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
        GenericPoolManager.CratePool<MissileScript>("Missile", missilePrefab, GameObject.Find("PoolParent").transform, 5);
        missilePool = GenericPoolManager.GetPool<MissileScript>("Missile");

        //input.onMouseLeftDown += Attack;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && attackCoolTimer <= Time.time)
        {
            Attack();
            attackCoolTimer = Time.time + attackCool;
        }
    }

    public void Attack()
    {
        Transform target = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1, whatIsEnemy)?.transform;

        if (target == null || target.GetComponent<IHitable>() == null)
        {
            return;
        }

        waitForSeconds = new WaitForSeconds(coolBetweenAttack);

        StartCoroutine(AttackCorutine(target));
    }

    IEnumerator AttackCorutine(Transform target)
    {
        for (int i = 0; i < missileCount; i++)
        {
            missilePool.GetPoolObject().InitMissile(transform.up, transform.position, target, missileSpeed, missileDamage);
            yield return waitForSeconds;
        }
    }
}
