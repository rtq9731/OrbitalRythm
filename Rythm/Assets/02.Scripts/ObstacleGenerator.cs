using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public static MapDataSO curMap = null;

    [SerializeField] GameTimer timer = null;

    int curObstacleIdx = 0;

    private void Update()
    {
        if (timer.GameTick >= curMap.obstacles[curObstacleIdx].tick)
        {
            
        }
    }
}
