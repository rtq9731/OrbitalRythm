using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootObj : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnEat(collision.transform);
            gameObject.SetActive(false);
        }
    }

    protected abstract void OnEat(Transform target);
}
