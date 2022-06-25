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

        for (int i = 0; i < 5; i++)
        {

        }
    }

    private T CreateObstacle<T>(ObstacleType type) where T : ObstacleScript
    {
        T result = Instantiate(obstaclePrefabs[(int)type]) as T;
        result.gameObject.SetActive(false);

        obstaclePoolDict[type].Enqueue(result);

        return result;
    }

    public T GetObstacle<T>(ObstacleType type, Obstacle data) where T : ObstacleScript
    {
        T result = null;

        if (!shortObstaclePool.Peek().gameObject.activeSelf)
        {
            result = CreateObstacle<T>(type);
        }
        else
        {
            result = obstaclePoolDict[type].Dequeue() as T;
            obstaclePoolDict[type].Enqueue(result);
        }

        result.data = data;

        switch (type)
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