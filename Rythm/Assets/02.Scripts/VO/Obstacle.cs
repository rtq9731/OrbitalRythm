using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    SHORT,
    LONG,
    HEAL
}

[System.Serializable]
public class Obstacle
{
    ObstacleType type;
    uint tick = 0;
}

public class ShortObstacle : Obstacle
{
    ObstacleType type = ObstacleType.SHORT;
    uint tick;
}

public class LongObstacle : Obstacle
{
    ObstacleType type = ObstacleType.LONG;
    uint tick = 0;
    uint endTick;
}

public class HealObstacle : Obstacle
{
    ObstacleType type = ObstacleType.HEAL;
    uint tick = 0;
    uint endTick;
}
