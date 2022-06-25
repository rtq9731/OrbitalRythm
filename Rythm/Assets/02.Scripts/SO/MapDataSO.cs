using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "MapDataso", menuName = "ScriptableObject/Mapdata")]
public class MapDataSO : ScriptableObject
{
    public string songName = "";
    public string makerName = "";

    public float bpm = 0f;
    public float songeSeconds = 0f;

    public long songTimeTick = 0;

    public List<Obstacle> obstacles;
}