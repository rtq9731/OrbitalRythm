using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    SHORT,
    LONG,
    HEAL
}

public enum ObstacleTypeInOutType
{
    Inner,
    Outer,
    Middle
}


[System.Serializable]
public class DataObstacle
{
    public ObstacleTypeInOutType inOutType = ObstacleTypeInOutType.Outer;
    public ObstacleType type;
    public uint tick = 0;

    // onlyEffect on longObstacle
    public uint endTick;

    // onlyEffect on healObstacle
    public uint heal;
}


public class Obstacle
{
    public ObstacleTypeInOutType inOutType = ObstacleTypeInOutType.Outer;
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
