using System;
using UnityEngine;

public class Points : MonoBehaviour
{
    public float Value { get; private set; }
    public event Action ValueChanged;

    public void AddValue(float value)
    {
        if (value < 0)
            throw new ArgumentException("AddValue(value <0): " + value);

        Value += value;
        ValueChanged?.Invoke();
    }

    public void Restart()
    {
        Value = 0;
        ValueChanged?.Invoke();
    }
}