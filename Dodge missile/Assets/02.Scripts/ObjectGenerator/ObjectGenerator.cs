using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator<T> : MonoBehaviour where T : MonoBehaviour
{
    string objectName = "";
    [SerializeField] protected T objectPrefab = null;

    protected GenericPool<T> objectPool = null;

    protected virtual void Start()
    {
        objectName = objectPrefab.name;

        objectPool = GenericPoolManager.CratePool<T>(objectName, objectPrefab, GameObject.Find("PoolParent").transform, 5);
    }
}
