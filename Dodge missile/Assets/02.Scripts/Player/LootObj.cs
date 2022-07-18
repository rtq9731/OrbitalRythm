using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootObj : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnEat();
            gameObject.SetActive(false);
        }
    }

    protected abstract void OnEat();
}
