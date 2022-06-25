using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public Action onTimerSet = null;

    bool isSetTimer = false;

    [SerializeField] float _gameTime = 0f;
    public float GameTime
    {
        get { return _gameTime; }
    }

    [SerializeField] uint _gameTick = 0;
    public float GameTick
    {
        get { return _gameTick; }
    }

    private void Start()
    {
        // Debug 코드 ( 나중에 삭제할것 )
        StartTimer();
    }

    private void Update()
    {
        if(isSetTimer)
        {
            _gameTime += Time.deltaTime;

            if(_gameTime >= 0 ) _gameTick = (uint)Mathf.RoundToInt(_gameTime * 1000);   
        }
    }

    public void StartTimer()
    {
        onTimerSet?.Invoke();
        isSetTimer = true;
    }
}
