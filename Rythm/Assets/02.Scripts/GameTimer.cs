using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    bool isSetTimer = false;

    float _gameTime = 0f;
    public float GameTime
    {
        get { return _gameTime; }
    }

    private void Update()
    {
        if(isSetTimer)
        {
            _gameTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isSetTimer = true;
    }
}
