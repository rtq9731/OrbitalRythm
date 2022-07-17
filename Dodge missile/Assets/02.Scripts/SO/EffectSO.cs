using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO", menuName = "ScriptableObject/EffectSO")]
public class EffectSO : ScriptableObject
{
    public List<EffectInfo> effects = new List<EffectInfo>();
}

[System.Serializable]
public class EffectInfo
{
    public string effectName = "";
    public EffectScript effectScript = null;
}

