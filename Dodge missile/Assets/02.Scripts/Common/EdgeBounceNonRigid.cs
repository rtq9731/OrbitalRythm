using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeBounceNonRigid : MonoBehaviour
{
    ObstacleScript obstacle = null;

    private void Awake()
    {
        obstacle = GetComponent<ObstacleScript>();
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < -0.1f)
        {
            pos.x = -0.1f;
            obstacle.rigid.velocity = new Vector2(Mathf.Abs(obstacle.rigid.velocity.x), obstacle.rigid.velocity.y);
        }
        if (pos.x > 1.1f)
        {
            pos.x = 1.1f;
            obstacle.rigid.velocity  = new Vector2(-Mathf.Abs(obstacle.rigid.velocity .x), obstacle.rigid.velocity.y);
        }
        if (pos.y < -0.1f)
        {
            pos.y = -0.1f;
            obstacle.rigid.velocity  = new Vector2(obstacle.rigid.velocity.x, Mathf.Abs(obstacle.rigid.velocity.y));
        }
        if (pos.y > 1.1f)
        {
            pos.y = 1.1f;
            obstacle.rigid.velocity  = new Vector2(obstacle.rigid.velocity.x, -Mathf.Abs(obstacle.rigid.velocity.y));
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
