using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool<T> where T : MonoBehaviour
{
    private Queue<T> queue;
    private Transform parent = null;

    private T prefab = null;

    public GenericPool(T prefab, Transform parent, int childCount = 5)
    {
        queue = new Queue<T>();

        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < childCount; i++)
        {
            CreatePoolObj();
        }
    }

    public T GetPoolObject(bool active = false)
    {
        T result = null;

        if (queue.Count > 0)
        {
            if (!(queue.Peek() as MonoBehaviour).gameObject.activeSelf)
            {
                result = queue.Dequeue();
                queue.Enqueue(result);
            }
            else
            {
                result = CreatePoolObj();
            }
        }
        else
        {
            result = CreatePoolObj();
        }

        result.gameObject.SetActive(active);

        return result;
    }

    public T GetPoolObject(float lifeTime)
    {
        T result = null;

        if (queue.Count > 0)
        {
            if (!queue.Peek().gameObject.activeSelf)
            {
                result = queue.Dequeue();
                queue.Enqueue(result);
            }
            else
            {
                result = CreatePoolObj();
            }
        }
        else
        {
            result = CreatePoolObj();
        }

        result.gameObject.SetActive(true);
        result.StartCoroutine(RemoveObj(result, lifeTime));

        return result;
    }

    private IEnumerator RemoveObj(MonoBehaviour obj, float sec)
    {
        yield return new WaitForSeconds(sec);
        obj.gameObject.SetActive(false);
    }

    private T CreatePoolObj()
    {
        T result = MonoBehaviour.Instantiate<T>(prefab, parent);
        queue.Enqueue(result);

        (result as MonoBehaviour).gameObject.SetActive(false);

        return result;
    }
}