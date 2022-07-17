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
            obstacle._velocity = new Vector2(Mathf.Abs(obstacle._velocity.x), obstacle._velocity.y);
        }
        if (pos.x > 1.1f)
        {
            pos.x = 1.1f;
            obstacle._velocity = new Vector2(-Mathf.Abs(obstacle._velocity.x), obstacle._velocity.y);
        }
        if (pos.y < -0.1f)
        {
            pos.y = -0.1f;
            obstacle._velocity = new Vector2(obstacle._velocity.x, Mathf.Abs(obstacle._velocity.x));
        }
        if (pos.y > 1.1f)
        {
            pos.y = 1.1f;
            obstacle._velocity = new Vector2(obstacle._velocity.x, -Mathf.Abs(obstacle._velocity.x));
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
