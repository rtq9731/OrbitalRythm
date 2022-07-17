using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public float timeScale = 1f;

    private void Awake()
    {
        _instance = this;
    }


}
