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
    public ObstacleType type;
    public uint tick = 0;
}

public class ShortObstacle : Obstacle
{

}

public class LongObstacle : Obstacle
{
    public uint endTick;
}

public class HealObstacle : Obstacle
{
    public uint heal;
}
