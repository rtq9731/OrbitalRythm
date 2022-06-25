using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleScript : MonoBehaviour
{
    public Obstacle data;

    public virtual void InitObstacle(uint timeTick, ObstacleTypeInOutType inOutType)
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

        transform.position = new Vector2(Mathf.Sin((timeTick / 1000f) % 360) * (10 + inOutPlusPos), Mathf.Cos((timeTick / 1000f) % 360) * (10 + inOutPlusPos));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.Dot(Vector2.up, (transform.position.x < 0 ? -transform.position.normalized : transform.position.normalized)) * Mathf.Rad2Deg));
        gameObject.SetActive(true);
    }
}
