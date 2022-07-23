using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : ObjectGenerator<ResourceScript>
{
    public void GenerateResource(Vector2 pos, int tier)
    {
        for (int i = 0; i < tier; i++)
        {
            ResourceScript obj = objectPool.GetPoolObject();

            obj.transform.position = pos + Utill.GetRandomDir();
            obj.gameObject.SetActive(true);
        }
    }
}
