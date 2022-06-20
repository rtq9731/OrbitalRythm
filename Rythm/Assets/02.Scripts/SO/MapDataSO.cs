using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "MapDataso", menuName = "ScriptableObject/Mapdata")]
public class MapDataSO : ScriptableObject
{
    string songName = "";
    string makerName = "";
    
    float bpm = 0f;
    float songeSeconds = 0f;

    long songTimeTick = 0;

    List<Obstacle> obstacles;
}