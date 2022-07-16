using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] MissileScript missilePrefab = null;

    private void Start()
    {
        GenericPoolManager.CratePool<MissileScript>("Misile", missilePrefab, GameObject.Find("PoolParent").transform, 5);   
    }

    private void Update()
    {
        
    }
}
