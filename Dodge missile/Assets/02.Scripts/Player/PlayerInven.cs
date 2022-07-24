using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInven : MonoBehaviour
{
    [SerializeField] ValueBarScript resourceBar;

    int _curResource = 0;

    int nextLevelResource = 3;

    private void Start()
    {
        resourceBar.RefreshMaxValue(nextLevelResource);
    }

    public void GetItem(int cost)
    {
        resourceBar.SetUpdateValue(cost);
        _curResource += cost;

        if(nextLevelResource <= _curResource)
        {
            nextLevelResource += (int)(nextLevelResource * 1.2f);
            resourceBar.RefreshMaxValue(nextLevelResource);
            resourceBar.ResetValue();
        }
    }


}
