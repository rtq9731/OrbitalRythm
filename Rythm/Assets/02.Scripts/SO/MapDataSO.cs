using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "MapDataSo", menuName = "ScriptableObject/Mapdata")]
public class MapDataSO : ScriptableObject
{
    public AudioClip audio = null;

    public string songName = "";
    public string makerName = "";

    public float bpm = 0f;
    public float songeSeconds = 0f;

    public long songTimeTick = 0;

    [SerializeField] List<DataObstacle> obstacleDatas = new List<DataObstacle>();
    [HideInInspector] public List<Obstacle> obstacles = new List<Obstacle>();

    private void OnEnable()
    {
        obstacles = ChangeDataToObstacles();
    }

    private List<Obstacle> ChangeDataToObstacles()
    {
        List<Obstacle> result = new List<Obstacle>();

        for (int i = 0; i < obstacleDatas.Count; i++)
        {
            DataObstacle curData = obstacleDatas[i];
            switch (obstacleDatas[i].type)
            {
                case ObstacleType.SHORT:
                    result.Add(new Obstacle { tick = curData.tick, type = curData.type });
                    break;
                case ObstacleType.LONG:
                    result.Add(new LongObstacle { tick = curData.tick, endTick = curData.endTick, type = curData.type });
                    break;
                case ObstacleType.HEAL:
                    result.Add(new HealObstacle { tick = curData.tick, type = curData.type, heal = curData.heal });
                    break;
                default:
                    break;
            }
        }

        return result;
    }
}