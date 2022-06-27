using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public MapDataSO curMap = null; // TODO : static¿∏∑Œ πŸ≤‹∞Õ.

    [SerializeField] ObstaclePoolManager pool = null;
    [SerializeField] GameTimer timer = null;

    int curObstacleIdx = 0;

    private void Update()
    {
        if(curMap.obstacles.Count <= curObstacleIdx)
        {
            enabled = false;
            return;
        }

        if (timer.GameTick >= curMap.obstacles[curObstacleIdx].tick - 1000)
        {
            Obstacle curObstacle = curMap.obstacles[curObstacleIdx];
            pool.GetObstacle<ObstacleScript>(curObstacle).InitObstacle(curObstacle.tick, curObstacle.inOutType);
            curObstacleIdx++;
        }
    }
}
