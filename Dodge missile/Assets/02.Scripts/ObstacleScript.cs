using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : Health
{

    public override void OnDie()
    {
        gameObject.SetActive(false);
    }
    
}
