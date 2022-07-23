using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utill
{

    /// <summary>
    /// 변수를 참조한 선형보간을 사용하여 4차 베지어 곡선 위에서 점의 위치를 가져옵니다.
    /// </summary>
    /// <param name="timing">선형보간에 참조할 수 입니다.</param>
    /// <param name="points">4차 베지어 곡선에 사용할 점의 위치들입니다.</param>
    /// <returns></returns>
    public static Vector2 GetBezierPoint(float timing, Vector2[] points)
    {
        return Vector2.Lerp(Vector2.Lerp(Vector2.Lerp(points[0], points[1], timing), Vector2.Lerp(points[1], points[2], timing), timing), Vector2.Lerp(Vector2.Lerp(points[1], points[2], timing), Vector2.Lerp(points[2], points[3], timing), timing), timing);
    }

    /// <summary>
    /// 목표까지의 임의의 점 4개를 뽑아옵니다.
    /// </summary>
    /// <param name="startPos">시작점의 위치입니다.</param>
    /// <param name="target">목표의 Transform입니다.</param>
    /// <returns></returns>
    public static Vector2[] GetNearPointsToTarget(Vector2 startPos, Transform target)
    {
        Vector2[] points = new Vector2[4];
        float[] timings = new float[4] { 0, 0, 0, 1 }; // 근처 점을 뽑아올 직선 상의 위치비 ( ex 0.5 -> 중간점 )

        for (int i = 1; i < 3; i++)
        {
            timings[i] = Random.Range(0, 1);
        }

        for (int i = 0; i < 4; i++)
        {
            Vector2 point = Vector2.Lerp(startPos, target.position, timings[i]);
            points[i] = point;
        }

        for (int i = 1; i < 3; i++)
        {
            points[i].x += Random.Range(-5, 5);
            points[i].y += Random.Range(-5, 5);
        }

        return points;
    }


    /// <summary>
    /// 랜덤한 방향을 반환합니다.
    /// </summary>
    /// <returns></returns>
    public static Vector2 GetRandomDir()
    {
        Vector2 result = Vector2.zero;

        do
        {
            result = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        while (result == Vector2.zero);

        return result;
    }
}
