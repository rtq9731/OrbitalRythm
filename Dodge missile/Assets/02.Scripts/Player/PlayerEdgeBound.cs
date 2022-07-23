using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEdgeBound : EdgeBounce
{
    private void Awake()
    {
        onEdgeCollide += (dir) =>
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(dir * 3, ForceMode2D.Impulse);
        };
    }
}
