using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GenericPoolManager
{
    private static Dictionary<string, object> poolDict = new Dictionary<string, object>();

    public static void FlushPool()
    {
        poolDict.Clear();
    }

    public static bool HasKey(string key)
    {
        return poolDict.ContainsKey(key);
    }

    public static void CratePool<T>(string key, T obj, Transform parent, int count) where T : MonoBehaviour
    {
        poolDict.Add(key, new GenericPool<T>(obj, parent, count));
    }

    public static GenericPool<T> GetPool<T>(string key) where T : MonoBehaviour
    {
        return poolDict[key] as GenericPool<T>;
    }
}