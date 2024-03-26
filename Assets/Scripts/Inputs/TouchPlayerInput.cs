using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerInput : PlayerInput
{
    public override event Action Touched;

    public void Touch()
    {
        if (!enabled) return;
        Touched?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Touched?.Invoke();
    }
}