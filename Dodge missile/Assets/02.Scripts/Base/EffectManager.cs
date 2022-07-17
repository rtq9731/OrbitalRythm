using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private static EffectManager _instance;

    [SerializeField] EffectSO effectSO = null;

    Dictionary<string, GenericPool<EffectScript>> poolDict = new Dictionary<string, GenericPool<EffectScript>>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < effectSO.effects.Count; i++)
        {
            GenericPoolManager.CratePool<EffectScript>(effectSO.effects[i].effectName, effectSO.effects[i].effectScript, GameObject.Find("PoolParent").transform, 5);
        }
    }

    public EffectScript GetEffect(string effectName)
    {
        return GenericPoolManager.GetPool<EffectScript>(effectName).GetPoolObject();
    }
}
