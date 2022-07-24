using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEdgeBound : EdgeBounce
{
    private void Start()
    {
        onEdgeCollide += (dir) =>
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(dir * 4, ForceMode2D.Impulse);
        };
    }
}
