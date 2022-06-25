using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePoolManager : MonoBehaviour
{
    [SerializeField] ObstacleScript[] obstaclePrefabs = null;

    Dictionary<ObstacleType, Queue<ObstacleScript>> obstaclePoolDict = new Dictionary<ObstacleType, Queue<ObstacleScript>>();

    Queue<ObstacleScript> shortObstaclePool = new Queue<ObstacleScript>();
    Queue<ObstacleScript> HealObstaclePool = new Queue<ObstacleScript>();
    Queue<ObstacleScript> LongObstaclePool = new Queue<ObstacleScript>();

    private void Start()
    {
        obstaclePoolDict.Add(ObstacleType.SHORT, shortObstaclePool);
        obstaclePoolDict.Add(ObstacleType.LONG, LongObstaclePool);
        obstaclePoolDict.Add(ObstacleType.HEAL, HealObstaclePool);

        for (int i = 0; i < Enum.GetNames(typeof(ObstacleType)).Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                CreateObstacle<ObstacleScript>((ObstacleType)i);
            }
        }

    }

    private T CreateObstacle<T>(ObstacleType type) where T : ObstacleScript
    {
        T result = Instantiate(obstaclePrefabs[(int)type], transform) as T;
        result.gameObject.SetActive(false);

        obstaclePoolDict[type].Enqueue(result);

        return result;
    }

    public T GetObstacle<T>(Obstacle data) where T : ObstacleScript
    {
        T result = null;

        if (!shortObstaclePool.Peek().gameObject.activeSelf)
        {
            result = CreateObstacle<T>(data.type);
        }
        else
        {
            result = obstaclePoolDict[data.type].Dequeue() as T;
            obstaclePoolDict[data.type].Enqueue(result);
        }

        result.data = data;

        switch (data.type)
        {
            case ObstacleType.SHORT:
                break;
            case ObstacleType.LONG:
                (result.data as LongObstacle).endTick = (data as LongObstacle).endTick;
                break;
            case ObstacleType.HEAL:
                (result.data as HealObstacle).heal = (data as HealObstacle).heal;
                break;
            default:
                break;
        }

        return result;
    }

}