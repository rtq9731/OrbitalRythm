using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongObstacleScript : ObstacleScript
{
    [SerializeField] LineRenderer lr = null;
    [SerializeField] Transform head;
    [SerializeField] Transform tail;

    public override void InitObstacle(uint timeTick, ObstacleTypeInOutType inOutType)
    {
        int inOutPlusPos = 0;
        switch (inOutType)
        {
            case ObstacleTypeInOutType.Inner:
                inOutPlusPos = -1;
                break;
            case ObstacleTypeInOutType.Outer:
                inOutPlusPos = 1;
                break;
            case ObstacleTypeInOutType.Middle:
            default:
                break;
        }

        uint endTick = (data as LongObstacle).endTick;

        head.position = new Vector2(Mathf.Sin(timeTick / 1000f) * (10 + inOutPlusPos), Mathf.Cos(timeTick / 1000f) * (10 + inOutPlusPos));
        tail.position = new Vector2(Mathf.Sin(endTick / 1000f) * (10 + inOutPlusPos), Mathf.Cos(endTick / 1000f) * (10 + inOutPlusPos));

        head.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.Dot(Vector2.up, (head.position.x < 0 ? -head.position.normalized : head.position.normalized)) * Mathf.Rad2Deg));
        tail.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.Dot(Vector2.up, (tail.position.x < 0 ? -tail.position.normalized : tail.position.normalized)) * Mathf.Rad2Deg));

        lr.positionCount = (int)GetMyLength();
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, GetPoint(lr.positionCount, i));
        }

        gameObject.SetActive(true);
    }

    private Vector3 GetPoint(float length, int number)
    {
        float angle = Vector2.Angle(Vector2.up, head.transform.position.normalized) * Mathf.Deg2Rad + GetAngleBetweenHeadAndTail() * (number / length); // number / length에 비례하는 라디안각을 구한다.

        Vector3 v = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0); 

        v *= 10;

        return v;
    }

    private float GetMyLength()
    {
        return 2 * Mathf.PI * 10 * (GetAngleBetweenHeadAndTail() * Mathf.Rad2Deg / 360f); // 2PIr * ( Angle / 360 ); 호의 길이 공식
    }

    private float GetAngleBetweenHeadAndTail()
    {
        return Vector2.Dot(head.position.normalized, tail.position.normalized);
    }
}
