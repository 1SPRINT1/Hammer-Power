using UnityEngine;
using System;

[System.Serializable]
public class ScalarFromTime
{
    [field: SerializeField] public float Time { get; private set; }
    [field: SerializeField] public float Scalar { get; private set; }
}

public class PointsAdderMultiplayer : DistancePointsAdder
{
    [SerializeField] private ScalarFromTime[] _scalarFromTimes;
    private float _startTime;

    private void Start()
    {
        SortScalarFromTimes();
        _startTime = GetCurrentTime();
    }

    protected override void SaveStartY()
    {
        base.SaveStartY();
        _startTime = GetCurrentTime();
    }

    protected override void CalculateFinalCointsCount(float distance)
    {
        float waiteTime = GetCurrentTime() - _startTime;
        float scalar = GetScalar(waiteTime);
        AddPoints(scalar);
    }

    [ContextMenu("SortScalarFromTimes")]
    private void SortScalarFromTimes()
    {
        Array.Sort(_scalarFromTimes, (x, y) => x.Time.CompareTo(y.Time));
    }

    private float GetScalar(float time)
    {
        foreach (var x in _scalarFromTimes)
            if (x.Time >= time) return x.Scalar;

        return _scalarFromTimes[^1].Scalar;
    }

    private float GetCurrentTime() => Time.timeSinceLevelLoad;
}