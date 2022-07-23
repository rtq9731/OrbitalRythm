using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utill
{

    /// <summary>
    /// ������ ������ ���������� ����Ͽ� 4�� ������ � ������ ���� ��ġ�� �����ɴϴ�.
    /// </summary>
    /// <param name="timing">���������� ������ �� �Դϴ�.</param>
    /// <param name="points">4�� ������ ��� ����� ���� ��ġ���Դϴ�.</param>
    /// <returns></returns>
    public static Vector2 GetBezierPoint(float timing, Vector2[] points)
    {
        return Vector2.Lerp(Vector2.Lerp(Vector2.Lerp(points[0], points[1], timing), Vector2.Lerp(points[1], points[2], timing), timing), Vector2.Lerp(Vector2.Lerp(points[1], points[2], timing), Vector2.Lerp(points[2], points[3], timing), timing), timing);
    }

    /// <summary>
    /// ��ǥ������ ������ �� 4���� �̾ƿɴϴ�.
    /// </summary>
    /// <param name="startPos">�������� ��ġ�Դϴ�.</param>
    /// <param name="target">��ǥ�� Transform�Դϴ�.</param>
    /// <returns></returns>
    public static Vector2[] GetNearPointsToTarget(Vector2 startPos, Transform target)
    {
        Vector2[] points = new Vector2[4];
        float[] timings = new float[4] { 0, 0, 0, 1 }; // ��ó ���� �̾ƿ� ���� ���� ��ġ�� ( ex 0.5 -> �߰��� )

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
    /// ������ ������ ��ȯ�մϴ�.
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
