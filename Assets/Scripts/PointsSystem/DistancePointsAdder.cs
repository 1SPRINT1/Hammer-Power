using UnityEngine;

public class DistancePointsAdder : MonoBehaviour
{
    [SerializeField] private WallJumper _wallJumper;
    [SerializeField] private Points _points; 
    [Space]
    [SerializeField] private float _pointsInUnit = 1f;

    private float _startY;

    private void OnEnable()
    {
        _wallJumper.MotionStarted += SaveStartY;
        _wallJumper.MotionStoped += OnMotionStoped;
    }

    private void OnDisable()
    {
        _wallJumper.MotionStarted -= SaveStartY;
        _wallJumper.MotionStoped -= OnMotionStoped;
    }

    private float GetCurrentY() => _wallJumper.transform.position.y;
    protected virtual void SaveStartY() => _startY = GetCurrentY();

    private void OnMotionStoped()
    {
        float distance = GetCurrentY() - _startY;

        if (distance < 0)
            return;

        CalculateFinalCointsCount(distance);
    } 

    protected virtual void CalculateFinalCointsCount(float distance)
    {
        float coints = CalculateCointsFromDistance(distance);
        AddPoints(coints);
    }

    protected void AddPoints(float value) => _points.AddValue(value);

    protected float CalculateCointsFromDistance(float distance)
        => _pointsInUnit * distance;
}
