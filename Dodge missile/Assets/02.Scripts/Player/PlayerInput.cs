using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput = 0f;
    public float verticalInput = 0f;

    public event Action onMouseLeftDown = () => { };

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if(Input.GetMouseButtonDown(0))
        {
            onMouseLeftDown?.Invoke();
        }
    }
}
