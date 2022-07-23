using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEdgeBound : EdgeBounce
{
    private void Start()
    {
        onEdgeCollide = (dir) =>
        {
            Vector2 velo = rigid.velocity;

            if(dir.x != 0)
            {
                velo.x *= -1;
            }
            else if (dir.y != 0)
            {
                velo.y *= -1;
            }

            rigid.velocity = Vector2.zero;
            rigid.AddForce(velo, ForceMode2D.Impulse);
        };
    }
}
