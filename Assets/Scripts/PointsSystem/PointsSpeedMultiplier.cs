using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpeedMultiplier : DistancePointsAdder
{
    [SerializeField] [Range(0, 1)] private float _adder = 0.35f;
    [SerializeField] [Range(0, 1)] private float _lossInSecond = 0.2f;
    [SerializeField] private float _maxMultiplier = 10f;
    public event Action Added;
    public event Action ValueChanged;

    public float Value { get; private set; }

    private void Update()
    {
        Value -= _lossInSecond * Time.deltaTime;
        Value = Mathf.Max(Value, 0f);

        ValueChanged?.Invoke();
    }

    protected override void SaveStartY()
    {
        Add();
        base.SaveStartY();
    }

    protected override void CalculateFinalCointsCount(float distance)
    {
        float points = Mathf.Max(distance * Value *_maxMultiplier, 1f);
        AddPoints(points);
    }

    private void Add()
    {
        Value += _adder;
        Value = Mathf.Min(Value, 1f);

        Added?.Invoke();
        ValueChanged?.Invoke();
    }
}
